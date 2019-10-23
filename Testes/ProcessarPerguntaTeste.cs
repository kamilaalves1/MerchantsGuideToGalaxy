using Executores;
using Fronteiras;
using Fronteiras.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testes
{
    public class ProcessarPerguntaTeste 
    {
        [Theory]
        [InlineData("how much wood could a woodchuck chuck if a woodchuck could chuck wood ")]
        [InlineData("What's is your name ")]
        public void NaoPoderaAceitarPerguntaSemInterrogacao(string pergunta)
        {
            var _processarPergunta = new Mock<IProcessarPergunta>();
            _processarPergunta.Setup(x => x.Executar(pergunta)).Returns(string.Empty);

            var teste = _processarPergunta.Object.Executar(pergunta);
            Assert.Equal(string.Empty, teste);
        }

        [Theory]
        [InlineData("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?")]
        [InlineData("What's is your name ?")]
        public void DeveraRetornarMensagemPadraoPerguntaSemSimbolos(string pergunta)
        {
            var _processarPergunta = new Mock<IProcessarPergunta>();
            _processarPergunta.Setup(x => x.Executar(pergunta)).Returns(Constantes.MSGERRO);

            var teste = _processarPergunta.Object.Executar(pergunta);
            Assert.Equal("I have no idea what you are talking about", teste);
        }



        [Theory]
        [InlineData("how much is pish tegj glob glob ?")]
        public void RespondePerguntasComMetais(string pergunta)
        {
            var _processarPergunta = new Mock<IProcessarPergunta>();
            _processarPergunta.Setup(x => x.Executar(pergunta)).Returns("pish tegj glob glob is 42");

            var teste = _processarPergunta.Object.Executar(pergunta);
            Assert.Equal("pish tegj glob glob is 42", teste);
        }

        [Theory]
        [InlineData("how many Credits is glob prok Silver ?")]
        public void RespondePerguntaSemMetais(string pergunta)
        {
            var _processarPergunta = new Mock<IProcessarPergunta>();
            _processarPergunta.Setup(x => x.Executar(pergunta)).Returns("glob prok  Silver  is  68  credits.");

            var teste = _processarPergunta.Object.Executar(pergunta);
            Assert.Equal("glob prok  Silver  is  68  credits.", teste);
        }

    }
}
