using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteFullStackGrupoKyly.Api.Models;
using TesteFullStackGrupoKyly.Api.Models.Request;
using TesteFullStackGrupoKyly.Core;
using TesteFullStackGrupoKyly.Core.Interfaces.Gateways;

namespace TesteFullStackGrupoKyly.Api.Controllers
{
    /// <summary>
    /// Controller para cadastros de produtos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="productsRepository">Repositório de produtos</param>
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        /// <summary>
        /// Buscar produtos
        /// </summary>
        /// <param name="filters">Filtros para busca de produto</param>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        public Models.PaginatedList<Product> Get([FromQuery] SearchProductFilters filters)
        {
            var response = _productsRepository.GetProductsPaginatedAsync(filters.SearchFilter, filters.PageIndex, filters.PageSize);

            return new Models.PaginatedList<Product>
            {
                Items = response.Select(a => new Product(a.Id, a.Reference, a.Description, a.Color, a.ColorDescription, a.SizeSequence, a.SizeDescription)).ToArray(),
                PageSize = response.PageSize,
                PageIndex = response.PageIndex,
                HasNextPage = response.HasNextPage,
                HasPreviousPage = response.HasPreviousPage,
                TotalItems = response.TotalItems,
                TotalPages = response.TotalPages
            };
        }

        /// <summary>
        /// Buscar produto
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns>Dados de um produto</returns>
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            return new Product { Id = id };
        }
    }
}