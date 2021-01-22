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
        /// <param name="pageIndex">Index da página</param>
        /// <param name="pageSize">Quantidade de itens por página</param>
        /// <returns>Lista de produtos</returns>
        PaginatedList<Product> GetProductsPaginatedAsync(string searchFilter, int pageIndex, int pageSize);
    }
}