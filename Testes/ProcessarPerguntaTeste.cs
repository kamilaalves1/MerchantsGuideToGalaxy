using Executores;
using Fronteiras.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testes
{
    public class ProcessarPerguntaTeste 
    {
        private readonly IObterMetal _obterMetal;
        private readonly IObterSimbolos _obterSimbolos;
        private readonly IComporNumeroRomano _comporNumeroRomano;
        private readonly ICalcularRomanoInteiro _calcularRomanoInteiro;
        private readonly ICalcularMoeda _calcularMoeda;
 
        public ProcessarPerguntaTeste(IObterMetal obterMetal, IObterSimbolos obterSimbolos, IComporNumeroRomano comporNumeroRomano, ICalcularRomanoInteiro calcularRomanoInteiro, ICalcularMoeda calcularMoeda)
        {
            _obterMetal = obterMetal;
            _obterSimbolos = obterSimbolos;
            _comporNumeroRomano = comporNumeroRomano;
            _calcularRomanoInteiro = calcularRomanoInteiro;
            _calcularMoeda = calcularMoeda;
 
        }

        [Fact]
        public void NaoPoderaAceitarPerguntaSemInterrogacao()
        {
            var _processarPergunta = new ProcessarPergunta(_obterMetal, _obterSimbolos, _comporNumeroRomano, _calcularRomanoInteiro, _calcularMoeda);
            var result = _processarPergunta.Executar("how much wood could a woodchuck chuck if a woodchuck could chuck wood ");
            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?")]
        [InlineData("What's is your name ?")]
        public void DeveraRetornarMensagemPadraoPerguntaSemSimbolos(string pergunta)
        {
            var _processarPergunta = new ProcessarPergunta(_obterMetal, _obterSimbolos, _comporNumeroRomano, _calcularRomanoInteiro, _calcularMoeda);
            var result = _processarPergunta.Executar(pergunta);
            Assert.Equal("I have no idea what you are talking about", result);
        }     

        [Fact]
        public void RespondePerguntasComMetais()
        {
            var _processarPergunta = new ProcessarPergunta(_obterMetal, _obterSimbolos, _comporNumeroRomano, _calcularRomanoInteiro, _calcularMoeda);
            var result = _processarPergunta.Executar("how much is pish tegj glob glob ?");
            Assert.Equal("pish tegj glob glob is 42", result);
        }

        [Fact]
        public void RespondePerguntaSemMetais()
        {
            var _processarPergunta = new ProcessarPergunta(_obterMetal, _obterSimbolos, _comporNumeroRomano, _calcularRomanoInteiro, _calcularMoeda);
            var result = _processarPergunta.Executar("how many Credits is glob prok Silver ?");
            Assert.Equal("glob prok Silver is 68 Credits", result);
        }

        public string Executar(string pergunta)
        {
            throw new NotImplementedException();
        }
    }
}
