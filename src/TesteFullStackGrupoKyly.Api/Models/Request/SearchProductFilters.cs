namespace TesteFullStackGrupoKyly.Api.Models.Request
{
    /// <summary>
    /// Filtros para buscar produtos
    /// </summary>
    public class SearchProductFilters
    {
        /// <summary>
        /// Identificador da referência
        /// </summary>
        public string SearchFilter { get; set; }

        /// <summary>
        /// Nr. Página
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// Qtde itens por página
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}