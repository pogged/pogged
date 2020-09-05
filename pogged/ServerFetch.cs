using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;
using pogged.Model;
using pogged.Model.Xml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace pogged
{
    public static class ServerFetch
    {
        public static MySqlConnection MySQL;
        public static void LoadEpisodes()
        {
            Console.WriteLine("start full fetch");
            foreach (Channel channel in MySQL.GetAll<Channel>())
            {
                LoadEpisodes(channel);
            }
        }
        public static void LoadEpisodes(Channel channel)
        {
            IEnumerable<Episode> oldEpisodes = MySQL.Query<Episode>("SELECT * FROM Episodes WHERE Channel=@ChannelId;", new { ChannelId = channel.Id });

            XElement xml = Download(channel);
            XRSS rss = SerializeXElement<XRSS>(xml);

            foreach (XChannel xChannel in rss.Channels)
            {
                Console.WriteLine($"fetch: {xChannel.Title}");
                foreach (XItem xItem in xChannel.Items)
                {
                    if (!(oldEpisodes.AsList<Episode>().Exists(delegate (Episode episode) { return episode.Title == xItem.Title[0]; })))
                    {
                        Console.WriteLine($"add: {xItem.Title[0]}");

                        Episode episode = Serializer.ToEpisode(xItem);
                        episode.Channel = channel.Id;

                        MySQL.Insert(episode);
                    }
                }
            }
        }

        public static XElement Download(Channel channel)
        {
            XElement xml = XElement.Load(channel.Url);
            return xml;
        }

        public static T SerializeXElement<T>(this XElement xElement)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(xElement.CreateReader());
        }

    }
}
