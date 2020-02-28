using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
        /// <param name="services">Serviços a serem adicionados no container</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                            new OpenApiInfo
                            {
                                Title = "Teste Fullstack Grupo Kyly",
                                Description = "API para Teste de Fullstack do Grupo Kyly",
                                Version = "v1",
                                Contact = new OpenApiContact() { Email = "maicon.friedel@gmail.com", Name = "Maicon Gabriel Friedel", Url = new Uri("https://github.com/maiconfriedel") }
                            });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors();
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Fullstack Grupo Kyly - v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(opt =>
            {
                opt.AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}