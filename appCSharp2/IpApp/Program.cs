using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IpDisplayApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure(app =>
                    {
                        app.Use(async (context, next) =>
                        {
                            if (context.Request.Path == "/")
                            {
                                var ipAddress = context.Connection.RemoteIpAddress.ToString();
                                await context.Response.WriteAsync($"<html><body><h1>Your IP Address</h1><p>{ipAddress}</p></body></html>");
                            }
                            else
                            {
                                await next();
                            }
                        });
                    });
                });
    }
}