using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullStackGrupoKyly.Core.Domain;
using TesteFullStackGrupoKyly.Core.Interfaces.Gateways;

namespace TesteFullStackGrupoKyly.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório de dados de produtos
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {

        /// <summary>
        /// Busca produtos
        /// </summary>
        /// <param name="searchFilter">Filtro de busca, pode ser qualquer coluna</param>
        /// <returns>Lista de produtos</returns>
        public Task<IEnumerable<Product>> GetProductsAsync(string searchFilter)
        {
            throw new System.NotImplementedException();
        }
    }
}