using Fronteiras.Enum;
using Fronteiras.Interfaces;
using MerchantsGuideToTheGalaxy_KamilaAlves;
using System;

namespace Executores
{
    public class CalcularMoeda : ICalcularMoeda
    {
        public double Calcular(Metais metal, int? numero)
        {
            if (numero == null || numero < 0)
                return 0;

            switch (metal)
            {
                case Metais.None:
                    return (int)numero;
                case Metais.Iron:
                    return (195.5 * (int)numero);
                case Metais.Gold:
                    return (14450 * (int)numero);
                case Metais.Silver:
                    return (17 * (int)numero);
                default:
                    return 0;
            }
        }
    }
}
