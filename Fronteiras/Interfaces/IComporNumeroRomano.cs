using System;
using System.Collections.Generic;
using System.Text;

namespace Fronteiras.Interfaces
{
    public interface IComporNumeroRomano
    {
        string Obter(List<Tuple<string, string>> numeroRomanoLista);
    }
}
