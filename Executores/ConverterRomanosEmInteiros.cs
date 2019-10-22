using Fronteiras.Enum;
using Fronteiras.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Executores
{
    public class ConverterRomanosEmInteiros : IConverterRomanosEmInteiros
    {
        public int Executar(List<Tuple<string, string>> numeroRomanoLista)
        {

            if (numeroRomanoLista.Count == 0)
                return 0;

            string numeroRomano = string.Empty;
            var listaRomanos = numeroRomanoLista.Select(x => x.Item2).ToList();
            foreach (var item in listaRomanos)
            {
                numeroRomano += item.ToString();
            }

            int posicao = 0;
            int qtdeCaracteresRomanos = numeroRomano.Length;
            var listaNumeros = new List<int>();

            for (int i = 0; i < qtdeCaracteresRomanos; i++)
            {
                var numeral = numeroRomano[posicao];
                var digito = Convert.ToInt32(Enum.Parse(typeof(Romanos), numeral.ToString()));

                var proximoDigito = 0;
                if (posicao < qtdeCaracteresRomanos - 1)
                {
                    char proximoCaracter = numeroRomano[posicao + 1];
                    proximoDigito = Convert.ToInt32(Enum.Parse(typeof(Romanos), proximoCaracter.ToString()));

                    if (proximoCaracter > digito)
                    {
                        digito = proximoDigito - digito;
                        posicao = 1;
                    }
                }
                listaNumeros.Add(digito);
                posicao = 1;           
            }

            var total = 0;
            foreach (var item in listaNumeros)
            {
                total = item + total;
            }
           
            return total;

        }

    }
}
