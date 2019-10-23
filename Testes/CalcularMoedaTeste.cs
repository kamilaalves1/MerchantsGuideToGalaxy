
using Executores;
using Fronteiras.Enum;
using Fronteiras.Interfaces;
using Xunit;

namespace Testes
{
    public class CalcularMoedaTeste 
    {
        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        public void ParametroInteiroNaoPoderaSerNulo(int? numero)
        {
           CalcularMoeda calcularMoeda = new CalcularMoeda();
           var teste = calcularMoeda.Calcular(Metais.None, numero);
           Assert.NotNull(teste);
           
        }

        [Theory]
        [InlineData(null)]
        public void ParametroMetalNaoPodeSerInvalido(Metais metal)
        {
            CalcularMoeda calcularMoeda = new CalcularMoeda();
            var teste = calcularMoeda.Calcular(metal, 42);
            Assert.NotNull(teste);
        }

        [Theory]
        [InlineData(Metais.Silver, null)]
        [InlineData(Metais.Gold, -1)]
        public void NaoPodeReceberMetalPreenchidoENumeroVazio(Metais metais, int? numero)
        {
            CalcularMoeda calcularMoeda = new CalcularMoeda();
            var teste = calcularMoeda.Calcular(metais, numero);
            Assert.NotNull(teste);
        }
    }
}
