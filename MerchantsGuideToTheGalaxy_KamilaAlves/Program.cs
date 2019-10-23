using Executores;
using Fronteiras.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MerchantsGuideToTheGalaxy_KamilaAlves
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {

            InjetarDependencias();

            Console.WriteLine("*********************************************************");
            Console.WriteLine("Merchant's Guide to the Galaxy -  Por Kamila Alves");
            Console.WriteLine("");
            Console.WriteLine("Valores: I=1 / V=5 / X=10 / L=50 / C=100 / D=500 / M=1000");
            Console.WriteLine("");
            Console.WriteLine("glob is I");
            Console.WriteLine("prok is V");
            Console.WriteLine("pish is X");
            Console.WriteLine("tegj is L");
            Console.WriteLine("");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("");
            Console.WriteLine("Entre com sua pergunta:");

            while (true)
            {
                var chamada = _serviceProvider.GetService<IProcessarPergunta>();
                Console.WriteLine(chamada.Executar(Console.ReadLine()));
                Console.ReadLine();
            }
        }

        private static void InjetarDependencias()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ICalcularMoeda, CalcularMoeda>();
            collection.AddScoped<ICalcularRomanoInteiro, CalcularRomanoInteiro>();
            collection.AddScoped<IComporNumeroRomano, ComporNumeroRomano>();
            collection.AddScoped<IProcessarPergunta, ProcessarPergunta>();
            collection.AddScoped<IObterSimbolos, ObterSimbolos>();
            collection.AddScoped<IObterMetal, ObterMetal>();

            _serviceProvider = collection.BuildServiceProvider();
        }


        private static void DisposeServico()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
