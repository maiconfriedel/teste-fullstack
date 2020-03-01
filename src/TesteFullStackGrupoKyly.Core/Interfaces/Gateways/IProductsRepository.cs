using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullStackGrupoKyly.Core.Domain;

namespace TesteFullStackGrupoKyly.Core.Interfaces.Gateways
{
    /// <summary>
    /// Interface para repositório de dados de produtos
    /// </summary>
    public interface IProductsRepository
    {

        /// <summary>
        /// Busca produtos
        /// </summary>
        /// <param name="searchFilter">Filtro de busca, pode ser qualquer coluna</param>
        /// <returns>Lista de produtos</returns>
        Task<IEnumerable<Product>> GetProductsAsync(string searchFilter);
    }
}