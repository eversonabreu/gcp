using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;

namespace Senac.GCP.API
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            const string arquivoPortaAluno = "porta_gcp.txt";
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (!File.Exists(Path.Combine(directory.FullName, arquivoPortaAluno)))
            {
                directory = directory.Parent;
            }

            string dadosPortaAluno = File.ReadAllText(Path.Combine(directory.FullName, arquivoPortaAluno));

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                              .UseKestrel()
                              .UseUrls(dadosPortaAluno)
                              .UseStartup<Startup>();
                });
        }
    }
}
