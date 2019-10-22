using System;
using System.Collections.Generic;
using System.Text;

namespace Fronteiras.Interfaces
{
    public interface IConverterRomanosEmInteiros
    {
        int Executar(List<Tuple<string, string>> listaRomano);
    }
}
