using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantsGuideToTheGalaxy_KamilaAlves
{
    public class Excecao : Exception
    {
        public Excecao(string mensagem) : base(mensagem)
        {
            nomeApp = "testKamila";
        }         
        public string nomeApp { get; set; }
    }
}
