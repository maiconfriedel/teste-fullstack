using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteFullStackGrupoKyly.Api.Models;
using TesteFullStackGrupoKyly.Api.Models.Request;

namespace TesteFullStackGrupoKyly.Api.Controllers
{
    /// <summary>
    /// Controller para cadastros de produtos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Buscar produtos
        /// </summary>
        /// <param name="filters">Filtros para busca de produto</param>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get([FromQuery]SearchProductFilters filters)
        {

            return new Product[] { new Product { Id = "1" }, new Product { Id = "2" } };
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