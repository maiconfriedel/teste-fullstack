using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesteFullStackGrupoKyly.Core.Interfaces.Gateways;
using TesteFullStackGrupoKyly.Infrastructure.EntityFramework;
using TesteFullStackGrupoKyly.Infrastructure.Repositories;

namespace TesteFullStackGrupoKyly.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adiciona os serviços da camada Infrastructure
        /// </summary>
        /// <param name="services">Serviços</param>
        /// <returns>Serviços adicionados</returns>
        public static IServiceCollection AddTesteFullStackGrupoKylyInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProductsRepository, ProductsRepository>();

            services.AddDbContext<TesteFullstackDbContext>(options => options.UseInMemoryDatabase("TesteFullstack"));

            return services;
        }
    }
}