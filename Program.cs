using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Test1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {   
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseKestrel(options =>
                        {
                            options.Listen(System.Net.IPAddress.Loopback, 7043, listenOptions =>
                            {
                                var builder = WebApplication.CreateBuilder(args);

                                try
                                {
                                    var connectionOptions = new HttpsConnectionAdapterOptions
                                    {
                                        SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                                        ClientCertificateMode = ClientCertificateMode.RequireCertificate,
                                        ServerCertificate = new X509Certificate2("./root.pfx", "1221")
                                    };
                                    builder.WebHost.ConfigureKestrel(options =>
                                        options.ConfigureEndpointDefaults(listenOptions =>
                                            listenOptions.UseHttps(connectionOptions)));
                                }
                                catch (Exception ex)
                                {
                                    var exApp = builder.Build();
                                    exApp.MapGet("/", () => "There is no valid certificate in directory!");
                                    exApp.Run();
                                }

                                var app = builder.Build();
                                app.MapGet("/", () => "Security problems Test!");
                                app.Run();
                            });
                        })
                            .UseStartup<Startup>();
                    });
        }
    }
}
