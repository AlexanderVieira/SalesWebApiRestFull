using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sales.Domain.Models;
using Sales.Infra.Data.Mapping;

namespace Sales.Infra.Data.Context
{
    /// <summary>
    /// Classe que representa o contexto do EntityFrameworkCore
    /// da aplicacao
    /// @Autor: Alexander Silva
    /// </summary>
    public class SalesContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }

        public SalesContext(DbContextOptions<SalesContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SellerMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // obtém a configuracoes do aplicativo
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define a base de dados
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
