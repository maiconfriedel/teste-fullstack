using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TesteFullStackGrupoKyly.Core;
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
        /// Interface para obter configurações
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="configuration">Interface para obter configurações</param>
        public ProductsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Busca produtos
        /// </summary>
        /// <param name="searchFilter">Filtro de busca, pode ser qualquer coluna</param>
        /// <returns>Lista de produtos</returns>
        public PaginatedList<Product> GetProductsPaginatedAsync(string searchFilter, int pageIndex, int pageSize)
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _configuration.GetConnectionString("Kyly"))))
            {
                var products = (from l in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _configuration.GetConnectionString("Kyly")), Encoding.GetEncoding("iso-8859-1")).Skip(1)
                                let x = l.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray()
                                select new Product(x[0], x[1], x[2], x[3], x[4], int.Parse(x[5]), x[6])
                                ).ToList();

                if (!string.IsNullOrWhiteSpace(searchFilter))
                {
                    int.TryParse(searchFilter, out int searchFilterInt);

                    products = products.Where(a => a.Id == searchFilter ||
                                                   a.Reference == searchFilter ||
                                                   a.Description == searchFilter ||
                                                   a.Color == searchFilter ||
                                                   a.ColorDescription == searchFilter ||
                                                   a.SizeDescription == searchFilter ||
                                                   a.SizeSequence == searchFilterInt).ToList();
                }

                var relevantList1 = (from l in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sample_db/lista_relevancia_1.txt"), Encoding.GetEncoding("iso-8859-1"))
                                     select l).ToArray();

                var relevantList2 = (from l in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sample_db/lista_relevancia_2.txt"), Encoding.GetEncoding("iso-8859-1"))
                                     select l).ToArray();

                List<Product> orderedProducts = new List<Product>();

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

                PaginatedList<Product> paginated = new PaginatedList<Product>(orderedProducts, pageIndex, pageSize);

                return paginated;
            }
            else
            {
                return new PaginatedList<Product>(null);
            }
        }
    }
}