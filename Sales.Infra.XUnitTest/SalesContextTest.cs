using Microsoft.EntityFrameworkCore;
using Sales.Infra.Data.Context;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace Sales.Infra.XUnitTest
{
    public class SalesContextTest
    {
        [Fact]
        public void TestSalesContextNoEmpty()
        {
            /* ================== Montando Cenario =================== */
            var options = new DbContextOptionsBuilder<SalesContext>()
                .UseInMemoryDatabase(databaseName: "ConnectionTest").Options;

            /* ================== Execucao =================== */
            using (var ctx = new SalesContext(options))
            {
                ctx.Sellers.Add(new Domain.Models.Seller { Id = 1, FirstName = "Sergio", LastName = "Murillo" });
                ctx.SaveChanges();

                /* ================== Verificacao =================== */

                // Testando com Assert
                //Assert.NotEmpty(ctx.Sellers.ToList());

                // Testando com FluentAssertions
                ctx.Sellers.ToList().Should().BeEmpty(ctx.Sellers.ToList().ToString(), 
                    $"O objeto esperado não corresponde com ao objeto obtido ({ctx.Sellers.ToList().ToString()})");
            }

        }
    }
}
