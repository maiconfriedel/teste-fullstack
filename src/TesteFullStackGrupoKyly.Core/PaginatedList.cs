using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteFullStackGrupoKyly.Core
{
    /// <summary>
    /// Lista páginada
    /// </summary>
    /// <typeparam name="T">Tipo de lista</typeparam>
    public class PaginatedList<T> : List<T>
    {
        /// <summary>
        /// Index da página que deseja obter
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Quantidade de itens por página
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int TotalItems { get; private set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="source">Lista a ser paginada</param>
        /// <param name="pageIndex">Index da página que deseja obter</param>
        /// <param name="pageSize">Quantidade de itens por página</param>
        public PaginatedList(IEnumerable<T> source, int pageIndex = 1, int pageSize = 10)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItems = source.Count();
            TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);

            if (source != null)
            {
                this.AddRange(source.Skip((PageIndex - 1) * PageSize).Take(PageSize));
            }
        }

        /// <summary>
        /// Verifica se há página anterior
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        /// <summary>
        /// Verifica se há proxima página
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }
    }
}