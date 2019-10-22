using Fronteiras.Interfaces;
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
            var simbolos = new List<Tuple<string, string>>();
            simbolos.Add(Tuple.Create("GLOB", "I"));
            simbolos.Add(Tuple.Create("PROK", "V"));
            simbolos.Add(Tuple.Create("PISH", "X"));
            simbolos.Add(Tuple.Create("TEGJ", "L"));

            List<string> simbolosLista = pergunta.ToUpper().Split(' ').ToList();
            List<Tuple<string, string>> numeroRomano = simbolos.Where(b => simbolosLista.Any(a => a == b.Item1)).ToList();
            return numeroRomano;
        }
    }
}

