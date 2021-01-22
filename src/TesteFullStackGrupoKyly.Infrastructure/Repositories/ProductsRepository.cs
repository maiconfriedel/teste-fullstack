using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteFullStackGrupoKyly.Core;
using TesteFullStackGrupoKyly.Core.Domain;
using TesteFullStackGrupoKyly.Core.Interfaces.Gateways;
using TesteFullStackGrupoKyly.Infrastructure.EntityFramework;

namespace TesteFullStackGrupoKyly.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório de dados de produtos
    /// </summary>
    internal class ProductsRepository : IProductsRepository
    {
        private readonly TesteFullstackDbContext _testeFullstackDbContext;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="configuration">Interface para obter configurações</param>
        public ProductsRepository(TesteFullstackDbContext testeFullstackDbContext)
        {
            _testeFullstackDbContext = testeFullstackDbContext;
        }

        /// <summary>
        /// Busca produtos
        /// </summary>
        /// <param name="searchFilter">Filtro de busca, pode ser qualquer coluna</param>
        /// <returns>Lista de produtos</returns>
        public async Task<PaginatedList<Product>> GetProductsPaginatedAsync(string searchFilter, int pageIndex, int pageSize)
        {
            var products = await _testeFullstackDbContext.Products.ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchFilter))
            {
                int.TryParse(searchFilter, out int searchFilterInt);

                products = products.Where(a => a.Id.ToLowerInvariant().Contains(searchFilter.ToLowerInvariant()) ||
                                               a.Reference.ToLowerInvariant().Contains(searchFilter.ToLowerInvariant()) ||
                                               a.Description.ToLowerInvariant().Contains(searchFilter.ToLowerInvariant()) ||
                                               a.Color.ToLowerInvariant().Contains(searchFilter.ToLowerInvariant()) ||
                                               a.ColorDescription.ToLowerInvariant().Contains(searchFilter.ToLowerInvariant()) ||
                                               a.SizeDescription.ToLowerInvariant().Contains(searchFilter.ToLowerInvariant()) ||
                                               a.SizeSequence == searchFilterInt).ToList();
            }

            var relevantList1 = await _testeFullstackDbContext.RelevantReferences.Where(a => a.Priority == 1).Select(a => a.Reference).ToArrayAsync();
            var relevantList2 = await _testeFullstackDbContext.RelevantReferences.Where(a => a.Priority == 2).Select(a => a.Reference).ToArrayAsync();

            List<EntityFramework.Models.Product> orderedProducts = new List<EntityFramework.Models.Product>();

            foreach (var item in relevantList1)
            {
                var add = products.Where(a => a.Reference == item).OrderBy(a => a.Id).ToList();

                if (add != null)
                {
                    orderedProducts.AddRange(add);
                    products.RemoveAll(a => add.Contains(a));
                }
            }

            foreach (var item in relevantList2)
            {
                var add = products.Where(a => a.Reference == item).OrderBy(a => a.Id).ToList();

                if (add != null)
                {
                    orderedProducts.AddRange(add);
                    products.RemoveAll(a => add.Contains(a));
                }
            }

            orderedProducts.AddRange(products.OrderBy(a => a.Id).ToList());

            PaginatedList<Product> paginated = new PaginatedList<Product>(orderedProducts.Select(a => new Product(a.Id, a.Reference, a.Description, a.Color, a.ColorDescription, a.SizeSequence, a.SizeDescription)), pageIndex, pageSize);

            return paginated;
        }
    }
}