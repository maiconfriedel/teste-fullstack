using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteFullStackGrupoKyly.Api.Models;

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
        /// <param name="referenceId">Identificador da referência</param>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get([FromQuery] string referenceId)
        {

            return new Product[] { new Product { Id = "1" }, new Product { Id = "2" } };
        }
    }
}