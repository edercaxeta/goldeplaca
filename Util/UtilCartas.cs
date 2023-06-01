using GolDePlaca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GolDePlaca.Util
{
    public static class UtilCartas
    {
        private static List<Carta> cartasPadrao = new List<Carta>()
        {

            new Carta(1, "Gol", 3),
            new Carta(2, "Pênalti", 2),
            new Carta(3, "Falta", 1),
            new Carta(4, "Cartão Amarelo", 1),
            new Carta(5, "Cartão Vermelho", 0),
            new Carta(6, "Energia", 2)
        };

        public static Carta SortearCarta()
        {
            //Testar retorno de cartas iguais: comenta tudo, descomenta isso abaixo e coloca o número do tipo que vc tipo quer
            //Carta cartaSorteada = cartasPadrao.First(carta => carta.Numero == 6);
            //Console.WriteLine($"\n{cartaSorteada.Tipo}");
            //return cartaSorteada;

            Random random = new Random();
            int numeroCarta = random.Next(1, 7);


            switch (numeroCarta)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                default:
                    break;
            }
            Carta cartaSorteada = cartasPadrao.First(carta => carta.Numero == numeroCarta);
            Console.WriteLine($"\n{cartaSorteada.Tipo}");
            return cartaSorteada;
        }
    }
}
