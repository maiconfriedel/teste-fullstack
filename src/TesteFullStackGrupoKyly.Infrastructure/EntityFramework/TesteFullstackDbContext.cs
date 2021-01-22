using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteFullStackGrupoKyly.Infrastructure.EntityFramework.Models;

namespace TesteFullStackGrupoKyly.Infrastructure.EntityFramework
{
    internal class TesteFullstackDbContext : DbContext
    {
        public TesteFullstackDbContext(DbContextOptions<TesteFullstackDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<RelevantReference> RelevantReferences { get; set; }
    }
}