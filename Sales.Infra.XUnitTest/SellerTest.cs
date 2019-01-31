using Sales.Domain.Models;
using Xunit;
using FluentAssertions;

namespace Sales.Infra.XUnitTest
{
    /// <summary>
    /// Classe de teste criada para garantir o funcionamento
    /// das operacoes realizadas pela classe
    /// @Autor: Alexander Silva
    /// </summary>
    public class SellerTest
    {
        [Fact]
        public void TestCreatingNewSeller()
        {
            /* ================== Montando Cenario =================== */
            var seller = new Seller { Id = 1, FirstName = "Sergio", LastName = "Murilo" };

            /* ================== Execucao =================== */


            /* ================== Verificacao =================== */
            
            // Testando com Assert
            //Assert.Equal(1, seller.Id);

            // Testando com FluentAssertions
            seller.Id.Should().Be(1, $"O Id esperado não corresponde com o Id do objeto ({seller.Id})");
        }
    }
}
