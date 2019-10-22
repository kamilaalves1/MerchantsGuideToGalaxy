using System;
using System.Collections.Generic;
using System.Text;

namespace Fronteiras.Interfaces
{
    public interface IObterSimbolos
    {
        List<Tuple<string, string>> Obter(string pergunta);
    }
}
