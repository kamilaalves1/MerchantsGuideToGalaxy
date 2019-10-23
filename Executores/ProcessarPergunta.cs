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
    public class ProcessarPergunta : IProcessarPergunta
    {
        private readonly IObterMetal _obterMetal;
        private readonly IObterSimbolos _obterSimbolos;
        private readonly IComporNumeroRomano _comporNumeroRomano;
        private readonly ICalcularRomanoInteiro _calcularRomanoInteiro;
        private readonly ICalcularMoeda _calcularMoeda;

        public ProcessarPergunta(IObterMetal obterMetal, IObterSimbolos obterSimbolos, IComporNumeroRomano comporNumeroRomano, ICalcularRomanoInteiro calcularRomanoInteiro, ICalcularMoeda calcularMoeda)
        {
            _obterMetal = obterMetal;
            _obterSimbolos = obterSimbolos;
            _comporNumeroRomano = comporNumeroRomano;
            _calcularRomanoInteiro = calcularRomanoInteiro;
            _calcularMoeda = calcularMoeda;
        }

        public string Executar(string pergunta)
        {
            try
            {
                if (pergunta == string.Empty)
                    return null;

                if (!pergunta.Contains("?"))
                    return Constantes.MSGNAOPERGUNTA;

                pergunta = pergunta.Replace("?", " ?");

                var listaSimbolos = _obterSimbolos.Obter(pergunta);
                var metal = _obterMetal.Obter(pergunta);
                var composicaoNumeroRomano = _comporNumeroRomano.Obter(listaSimbolos);
                double numero = _calcularRomanoInteiro.Executar(composicaoNumeroRomano);
                var creditos = _calcularMoeda.Calcular(metal, (int)numero);

                return creditos > 0 ? metal == Metais.None ? string.Format("{0} {1} {2}", ConcatenarSimbolos(listaSimbolos.Select(x => x.Item1).ToList()), " is ", creditos.ToString()) : string.Format("{0} {1} {2} {3} {4}", ConcatenarSimbolos(listaSimbolos.Select(x => x.Item1).ToList()), metal, " is ", creditos.ToString(), " credits.") : Constantes.MSGERRO;

            }
            catch (Exception ex)
            {
                throw new Excecao(ex.ToString());
            }

        }

        string ConcatenarSimbolos(List<string> simbolosLista)
        {
            StringBuilder sbResultado = new StringBuilder();
            foreach (var item in simbolosLista)
            {
                sbResultado.Append(item);
                sbResultado.Append(" ");
            }
            return sbResultado.ToString().ToLower();
        }
    }
}
