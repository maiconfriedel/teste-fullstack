using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Text;
using TesteFullStackGrupoKyly.Infrastructure.EntityFramework.Models;

namespace TesteFullStackGrupoKyly.Infrastructure
{
    /// <summary>
    /// Exstensão para o application builder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Realiza atualização da base de dados do KylyOrderPicking
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <returns>Application Builder</returns>
        public static IApplicationBuilder PopulateDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            if (app is null)
            {
                throw new System.ArgumentNullException(nameof(app));
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration.GetValue<string>("SampleDbPath"))))
                {
                    using var context = serviceScope.ServiceProvider.GetService<EntityFramework.TesteFullstackDbContext>();
                    var products = (from l in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration.GetValue<string>("SampleDbPath")), Encoding.GetEncoding("iso-8859-1")).Skip(1)
                                    let x = l.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray()
                                    select new Product()
                                    {
                                        Id = x[0],
                                        Reference = x[1],
                                        Description = x[2],
                                        Color = x[3],
                                        ColorDescription = x[4],
                                        SizeSequence = int.Parse(x[5]),
                                        SizeDescription = x[6]
                                    }
                                    ).ToList();

                    var relevantList = (from l in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sample_db/lista_relevancia_1.txt"), Encoding.GetEncoding("iso-8859-1"))
                                        select l).ToList();

                    var relevantList2 = (from l in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sample_db/lista_relevancia_2.txt"), Encoding.GetEncoding("iso-8859-1"))
                                         select l).ToList();

                    context.Products.AddRange(products);
                    context.RelevantReferences.AddRange(relevantList.Select(a => new RelevantReference { Reference = a, Priority = 1 }));
                    context.RelevantReferences.AddRange(relevantList2.Select(a => new RelevantReference { Reference = a, Priority = 2 }));

                    context.SaveChanges();
                }

                return app;
            }
        }
    }
}