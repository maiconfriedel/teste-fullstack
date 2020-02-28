using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TesteFullStackGrupoKyly.Api
{
    /// <summary>
    /// Classe principal do projeto
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método Main, chamado para iniciar a API
        /// </summary>
        /// <param name="args">Argumentos</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Cria um HostBuilder
        /// </summary>
        /// <param name="args">Argumento</param>
        /// <returns>WebHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}