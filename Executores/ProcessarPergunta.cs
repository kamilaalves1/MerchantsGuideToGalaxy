using Fronteiras;
using Fronteiras.Enum;
using Fronteiras.Interfaces;
using MerchantsGuideToTheGalaxy_KamilaAlves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Executores
{
    public class ProcessarPergunta : IProcessarPergunta
    {
        private readonly IObterMetal _obterMetal;
        private readonly IObterSimbolos _obterSimbolos;
        private readonly IConverterRomanosEmInteiros _converterRomanosEmInteiros;

        public ProcessarPergunta(IObterMetal obterMetal, IObterSimbolos obterSimbolos, IConverterRomanosEmInteiros converterRomanosEmInteiros)
        {
            _obterMetal = obterMetal;
            _obterSimbolos = obterSimbolos;
            _converterRomanosEmInteiros = converterRomanosEmInteiros;
        }

        public string Executar(string pergunta)
        {
            try
            {
                if (pergunta == string.Empty)
                    return null;

                if (!pergunta.Contains("?"))
                    return new Excecao(Constantes.MSGNAOPERGUNTA).ToString();

                pergunta = pergunta.Replace("?", " ?");

                var listaSimbolos = _obterSimbolos.Obter(pergunta);
                var metal = (Metais)_obterMetal.Obter(pergunta);
                var valorRomanosEmInteiros = _converterRomanosEmInteiros.Executar(listaSimbolos);
                return null;
                //var romanNumbers = ConvertGalacticToRoman(comands);
                //var metal = Metal.ReturnMetal(input);
                //var credit = CalculateGalacticCredit(metal, romanNumbers);
                //if (credit > 0)
                //{
                //    if (metal == MetalType.None)
                //        return string.Concat(comands.ToLower(), "is ", credit.ToString());
                //    else
                //        return string.Concat(comands.ToLower(), metal, " is ", credit.ToString(), " Credits");
                //}
                //else
                //    return "I have no idea what you are talking about";

            }
            catch (Exception ex)
            {
                throw new Excecao(ex.ToString());
            }

        }
    }
}
