using Dapper;
using Microsoft.VisualBasic;
using MySqlConnector;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace pogged.Fetch
{
    class Program 
    {

        static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            pogged.ServerFetch.MySQL = new MySqlConnection(new MySqlConnectionStringBuilder
            {
                Server = Environment.GetEnvironmentVariable("server"),
                Port = Convert.ToUInt32(Environment.GetEnvironmentVariable("port")),
                UserID = Environment.GetEnvironmentVariable("user"),
                Password = Environment.GetEnvironmentVariable("password"),
                Database = Environment.GetEnvironmentVariable("database")
            }.ToString());
            pogged.ServerFetch.MySQL.Open();
            pogged.ServerFetch.MySQL.Query(pogged.Sql.CreateTables);

            if (!(String.IsNullOrEmpty(Environment.GetEnvironmentVariable("interval")) || Convert.ToInt32(Environment.GetEnvironmentVariable("interval")) == 0))
            {
                Console.WriteLine("start timer");
                new Program().NoClose(Convert.ToInt32(Environment.GetEnvironmentVariable("interval"))).GetAwaiter().GetResult();
            }
            else
            {
                pogged.ServerFetch.LoadEpisodes();
            }
        }


        static readonly Timer timer = new Timer();
        static void StartTimer(int ms)
        {
            timer.Interval = ms;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("interval") + " ms over");
            Task.Run(pogged.ServerFetch.LoadEpisodes);
        }

        public async Task NoClose(int ms)
        {
            StartTimer(ms);
            await Task.Delay(-1);
        }
    }
}
