using Fronteiras.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fronteiras.Interfaces
{
    public interface ICalcularMoeda
    {
        double Calcular(Metais metal, int? numero);
    }
}
