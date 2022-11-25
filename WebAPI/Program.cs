using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BaselAPI;
using WebAPI.PlacesAPI;

namespace WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var baselAPIClient = host.Services.GetRequiredService<BaselAPIClient>();
            var baselAPIDataBucket = host.Services.GetRequiredService<BaselAPIDataBucket>();

            var entsorgungsStellen = await baselAPIClient.LoadEntsorgungsstellen();

            baselAPIDataBucket.Entsorgungsstellen = entsorgungsStellen;

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext) =>
            {
                hostingContext.AddAzureKeyVault(new Uri("https://monbajour.vault.azure.net/"),
                        new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = "98c0e406-08c2-420c-86ff-db02ce54f55c" }));
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
