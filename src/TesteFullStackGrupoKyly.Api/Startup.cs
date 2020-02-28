using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TesteFullStackGrupoKyly.Api
{
    /// <summary>
    /// Classe que executa quando a API é iniciada, apenas uma vez
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="configuration">Configurações</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configurações
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Método para adicionar serviços ao container 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        /// <summary>
        /// Método para dizer quais serviços utilizar
        /// </summary>
        /// <param name="app">Builder de aplicativo</param>
        /// <param name="env">Environment (Dev, Stage, Prod)</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}