using Fronteiras.Enum;
using Fronteiras.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Executores
{
    public class ObterMetal : IObterMetal
    {
        public Metais Obter(string pergunta)
        {
            var palavras = pergunta.ToUpper().Split(" ");
            foreach (var palavra in palavras)
            {
                switch (palavra)
                {
                    case "SILVER":
                        return Metais.Silver;
                    case "GOLD":
                        return Metais.Gold;
                    case "IRON":
                        return Metais.Iron;
                    default:
                        break;
                }
            }
            return Metais.None;
        }
    }
}
