using Fronteiras;
using Fronteiras.Enum;
using Fronteiras.Interfaces;
using MerchantsGuideToTheGalaxy_KamilaAlves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Executores
{
    public class ComporNumeroRomano : IComporNumeroRomano
    {
        public string Obter(List<Tuple<string, string>> numeroRomanoLista)
        {
            try
            {
                if (numeroRomanoLista.Count == 0)
                    return null;

                string numeroRomano = string.Empty;

                if (numeroRomanoLista.GroupBy(x => x).Where(g => g.Count() > 3).Select(y => y.Key).ToList().Count > 1)
                    return Constantes.MSGALGARISMOTRIPLICADO;

                var listaRomanos = numeroRomanoLista.Select(x => x.Item2).ToList();
                foreach (var item in listaRomanos)
                {
                    numeroRomano += item.ToString();
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
