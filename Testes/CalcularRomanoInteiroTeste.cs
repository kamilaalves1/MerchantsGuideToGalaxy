using Executores;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testes
{
    public class CalcularRomanoInteiroTeste
    {
        [Theory]
        [InlineData(null)]
        public void ParametroNumeroRomanoNaoPoderaSerNulo(string numeroRomano)
        {
            CalcularRomanoInteiro calcularRomanoInteiro = new CalcularRomanoInteiro();
            var teste = calcularRomanoInteiro.Executar(numeroRomano);
            Assert.NotNull(teste);

        }

        [Theory]
        [InlineData(null)]
        public void DeveraRetornarExceptionRomanoInvalido(string numeroRomano)
        {
            CalcularRomanoInteiro calcularRomanoInteiro = new CalcularRomanoInteiro();
            var teste = calcularRomanoInteiro.Executar(numeroRomano);
            Assert.Equal(0, teste);
        }
    }
}
