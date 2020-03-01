using System;
using Microsoft.Extensions.DependencyInjection;

namespace TesteFullStackGrupoKyly.Core
{
    /// <summary>
    /// Adiciona os serviços da camada Core a coleção de serviços
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adiciona os serviços da camada Core
        /// </summary>
        /// <param name="services">Serviços</param>
        /// <returns>Serviços adicionados</returns>
        public static IServiceCollection AddTesteFullStackGrupoKylyCore(this IServiceCollection services)
        {

            return services;
        }
    }
}
