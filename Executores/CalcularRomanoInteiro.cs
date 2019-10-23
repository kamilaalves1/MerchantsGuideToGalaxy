using Fronteiras.Enum;
using Fronteiras.Interfaces;
using MerchantsGuideToTheGalaxy_KamilaAlves;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Executores
{
    public class CalcularRomanoInteiro : ICalcularRomanoInteiro
    {
        public double Executar(string numeroRomano)
        {
            try
            {
                int[] ValoresRomanos;
                int tamanhoNumeroRomano;
                var soma = 0;

                tamanhoNumeroRomano = numeroRomano.Length;

                if (tamanhoNumeroRomano == 0)
                {
                    return 0;
                }

                ValoresRomanos = new int[tamanhoNumeroRomano + 1];
                for (int numero = 0; numero < tamanhoNumeroRomano; numero++)
                {
                    switch (numeroRomano.Substring(numero, 1))
                    {
                        case "M":
                            {
                                ValoresRomanos[numero] = 1000;
                                break;
                            }

                        case "D":
                            {
                                ValoresRomanos[numero] = 500;
                                break;
                            }

                        case "C":
                            {
                                ValoresRomanos[numero] = 100;
                                break;
                            }

                        case "L":
                            {
                                ValoresRomanos[numero] = 50;
                                break;
                            }

                        case "X":
                            {
                                ValoresRomanos[numero] = 10;
                                break;
                            }

                        case "V":
                            {
                                ValoresRomanos[numero] = 5;
                                break;
                            }

                        case "I":
                            {
                                ValoresRomanos[numero] = 1;
                                break;
                            }
                    }
                }

                for (int i = 0; i < tamanhoNumeroRomano; i++)
                {
                    if (i == tamanhoNumeroRomano)
                        soma = soma + ValoresRomanos[i];
                    else if (ValoresRomanos[i] >= ValoresRomanos[i + 1])
                        soma = soma + ValoresRomanos[i];
                    else
                        soma = soma - ValoresRomanos[i];
                }

                return soma;
            }
            catch (Exception ex)
            {
                throw new Excecao(ex.ToString());
            }
        }    
    }
}

