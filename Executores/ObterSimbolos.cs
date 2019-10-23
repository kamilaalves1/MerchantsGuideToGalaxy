using Fronteiras.Interfaces;
using MerchantsGuideToTheGalaxy_KamilaAlves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Executores
{
    public class ObterSimbolos : IObterSimbolos
    {
        public List<Tuple<string, string>> Obter(string pergunta)
        {
            try
            {
                var simbolos = new List<Tuple<string, string>>();
                simbolos.Add(Tuple.Create("GLOB", "I"));
                simbolos.Add(Tuple.Create("PROK", "V"));
                simbolos.Add(Tuple.Create("PISH", "X"));
                simbolos.Add(Tuple.Create("TEGJ", "L"));

                List<string> simbolosLista = pergunta.ToUpper().Split(' ').ToList();
                var numeroRomano = new List<Tuple<string, string>>();
                foreach (var item in simbolosLista.Where(x => simbolos.Any(b => b.Item1 == x)))
                {
                    numeroRomano.Add(Tuple.Create(item, simbolos.Where(r => r.Item1 == item).Select(c => c.Item2).FirstOrDefault()));
                }
                return numeroRomano;
            }
            catch (Exception ex)
            {
                throw new Excecao(ex.ToString());
            }
        }
    }
}

