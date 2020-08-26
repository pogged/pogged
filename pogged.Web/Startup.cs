using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;

namespace pogged.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string serverName = Configuration.GetValue<string>("serverName");
            uint port = Configuration.GetValue<uint>("port");
            string userId = Configuration.GetValue<string>("userId");
            string password = Configuration.GetValue<string>("password");
            services.AddControllersWithViews();

            MySqlConnectionStringBuilder ConnectionBuilder = new MySqlConnectionStringBuilder();
            ConnectionBuilder.Server = Configuration.GetValue<string>("server");
            ConnectionBuilder.Port = Configuration.GetValue<uint>("port");
            ConnectionBuilder.UserID = Configuration.GetValue<string>("user");
            ConnectionBuilder.Password = Configuration.GetValue<string>("password");
            ConnectionBuilder.Database = Configuration.GetValue<string>("database");
            ConnectionBuilder.AllowUserVariables = true;
            ConnectionBuilder.AllowZeroDateTime = true;

            MySqlConnection MySQL = new MySqlConnection(ConnectionBuilder.ConnectionString);
            MySQL.Open();

            services.AddTransient(e => MySQL);

            services.AddRazorPages();
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
