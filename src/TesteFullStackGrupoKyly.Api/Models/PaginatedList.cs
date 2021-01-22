using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFullStackGrupoKyly.Api.Models
{
    /// <summary>
    /// Lista paginada
    /// </summary>
    public class PaginatedList<T>
    {
        /// <summary>
        /// Itens da página
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Indica se há próxima pagina
        /// </summary>
        public bool HasNextPage { get; set; }

        /// <summary>
        /// Indica se há página anterior
        /// </summary>
        public bool HasPreviousPage { get; set; }

        /// <summary>
        /// Indicie da página
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Quantidade de itens por página
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Quantidade total de itens
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int TotalPages { get; set; }
    }
}