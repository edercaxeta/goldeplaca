using GolDePlaca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolDePlaca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao ;
            Console.WriteLine("--Escolha se Adversario--");
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("| Opção|                 |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("| 1 | Single Player      |");
            Console.WriteLine("| 2 | MultiPlayer        |");
            Console.WriteLine("|------------------------|");
            Console.Write("-->");
            opcao = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Player playerUm = new Player();
            Player playerdois = new Player();

            Console.WriteLine("Digite seu nome: ");
            playerUm.Nome = Console.ReadLine();
    
            Console.WriteLine();

            if (opcao == 1)
            {
                playerdois.Nome = "Pele";
                Console.Clear();
                Console.WriteLine("{0} Vs {1}", playerUm.Nome, playerdois.Nome);
            }
            else if (opcao == 2)
            { 
                Console.WriteLine("Digite seu nome: ");
                playerdois.Nome = Console.ReadLine();
                Console.WriteLine();

                Console.Clear();
                Console.WriteLine("{0} Vs {1}", playerUm.Nome, playerdois.Nome);
            }
            else
            {
                Console.WriteLine("Opção Invalida");
            }

            Console.WriteLine("Qual o primeiro jogardor");
            Random random = new Random();
            int primeiroAJogar = random.Next(1, 3);

            int total = 0;
            if (primeiroAJogar == 1)
            {
                Console.WriteLine("Quem irá começar será {0}", playerUm.Nome);
                Console.WriteLine();
                Console.WriteLine("{0} Escolhe uma carta:",playerUm.Nome);

                List<Cartas> lstCarta = new List<Cartas>();
                

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Escolha a carta " + (i + 1));
                    Random cartaSelecionada = new Random();
                    Cartas objCarta = new Cartas();

                    int valorCarta = cartaSelecionada.Next(1, 7);
                    objCarta.valorCarta = valorCarta;

                    lstCarta.Add(objCarta);
                }

                if (lstCarta[0].valorCarta == lstCarta[1].valorCarta
                    && lstCarta[1].valorCarta == lstCarta[2].valorCarta)
                {
                    //Gol
                }
                else 
                { 
                
                }


                //int valorCarta = carta.Next(1, 7);
                //if(valorCarta == 1)//gol
                //{
                //    total += 3;
                //}
                //else if(valorCarta== 2)//penalti
                //{
                //    total += 2;

                //}
                //else if (valorCarta == 3)//falta
                //{
                //    total++;
                //}
                //else if (valorCarta == 4)//cartao amarelo
                //{
                //    total ++;
                //}
                //else if (valorCarta== 5)//cartao vermelho
                //{
                //    total += 0;
                //}
                //else
                //{
                //    total--;
                //}
               
            }
            else
            {
                Console.WriteLine("Quem irá começar será {1}", playerdois.Nome);
            }
            Console.ReadLine();



        }
    }
}

//public Player RealizarJogada()
//{
//    List<Cartas> lstCarta = new List<Cartas>();

//    for (int i = 0; i < 3; i++)
//    {
//        Console.WriteLine("Escolha a carta " + (i + 1));
//        Random cartaSelecionada = new Random();
//        Cartas objCarta = new Cartas();

//        int valorCarta = cartaSelecionada.Next(1, 7);
//        objCarta.valorCarta = valorCarta;

//        lstCarta.Add(objCarta);
//    }

//    AtualizarPontuacao();
//}

//public void AtualizarPontuacao()
//{

//}