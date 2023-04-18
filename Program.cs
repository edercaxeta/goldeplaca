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
            //inicializando
            Player playerUm = new Player();
            Player playerdois = new Player();

            //inicilizando energia
            playerUm.Energia = 10;
            playerdois.Energia = 10;

            //inicializando gol
            playerUm.Gol = 0;
            playerdois.Gol = 0;

            //inicializando pontos
            playerUm.Pontos = 0;
            playerdois.Pontos = 0;
            int opcao;

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

            Console.WriteLine("Digite seu nome: ");
            playerUm.Nome = Console.ReadLine();
            Console.WriteLine();

            if (opcao == 1)
            {
                playerdois.Nome = "PELE";
                Console.Clear();
                Console.WriteLine("{0} Vs {1}", playerUm.Nome.ToUpper(), playerdois.Nome.ToUpper());
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Digite seu nome: ");
                playerdois.Nome = Console.ReadLine();
                Console.WriteLine();

                Console.Clear();
                Console.WriteLine("{0} Vs {1}", playerUm.Nome.ToUpper(), playerdois.Nome.ToUpper());
            }
            else
            {
                Console.WriteLine("Opção Invalida");
            }

            //placar de energia
            Console.Clear();
            playerUm.Painel(playerUm, playerdois);


            //sorteio de quem irá começar
            Random random = new Random();
            int primeiroAJogar = random.Next(1, 3);

            if (primeiroAJogar == 1)
            {
                Console.WriteLine("Quem irá começar será o {0}", playerUm.Nome.ToUpper());
                Console.WriteLine();
                Console.WriteLine("{0} escolha uma carta:", playerUm.Nome.ToUpper());
                Console.WriteLine();

                List<Cartas> lstCarta = new List<Cartas>();


                for (int i = 0; i < 3; i++)
                {
                    //seleção de carta
                    Random cartaSelecionada = new Random();
                    int valorCarta = cartaSelecionada.Next(1, 7);

                    Console.WriteLine("\nAperte enter para escolher a {0}° carta:", i + 1);
                    Console.ReadKey();

                    switch (valorCarta)
                    {
                        case 1:
                            Console.WriteLine("\nGOL");
                            break;
                        case 2:
                            Console.WriteLine("\nPÊNALTI");
                            break;
                        case 3:
                            Console.WriteLine("\nFALTA");
                            break;
                        case 4:
                            Console.WriteLine("\nCARTÃO AMARELO");
                            break;
                        case 5:
                            Console.WriteLine("\nCARTÃO VERMELHO");
                            break;
                        case 6:
                            Console.WriteLine("\nENERGIA");
                            break;

                    }

                    Console.ReadKey();
                    Cartas objCarta = new Cartas();
                    objCarta.valorCarta = valorCarta;
                    lstCarta.Add(objCarta);

                }
                if (lstCarta[0].valorCarta == 1 && lstCarta[1].valorCarta == 1 && lstCarta[2].valorCarta == 1)
                {
                    Console.WriteLine("Goooooooool");
                }
                else if (lstCarta[0].valorCarta == 2 && lstCarta[1].valorCarta == 2 && lstCarta[2].valorCarta == 2)
                {
                    Console.WriteLine("Pênalti");
                }
                else if (lstCarta[0].valorCarta == 3 && lstCarta[1].valorCarta == 3 && lstCarta[2].valorCarta == 3)
                {
                    Console.WriteLine(" Três Faltas, PASSOU A VEZ");
                }
                else if (lstCarta[0].valorCarta == 4 && lstCarta[1].valorCarta == 4 && lstCarta[2].valorCarta == 4)
                {
                    Console.WriteLine("Três Cartões amarelos, PERDEU UMA ENERGIA");
                    Console.WriteLine("ALERTA!!!! Proximo sera duas ");
                }
                else if (lstCarta[0].valorCarta == 5 && lstCarta[1].valorCarta == 5 && lstCarta[2].valorCarta == 5)
                {
                    Console.WriteLine("Três Cartões Vermelho, PERDEU DUAS ENERGIA");
                    Console.WriteLine("Passou a Vez ");
                }
                else
                {
                    //gol
                    if (lstCarta[0].valorCarta == 1)
                        playerUm.Pontos+= 3;
                    if (lstCarta[1].valorCarta == 1)
                        playerUm.Pontos += 3;
                    if (lstCarta[2].valorCarta == 1)
                        playerUm.Pontos += 3;

                    //penalti
                    if (lstCarta[0].valorCarta == 2)
                        playerUm.Pontos += 2;
                    if (lstCarta[1].valorCarta == 2)
                        playerUm.Pontos += 2;
                    if (lstCarta[2].valorCarta == 2)
                        playerUm.Pontos += 2;

                    //falta
                    if (lstCarta[0].valorCarta == 3)
                        playerUm.Pontos += 1;
                    if (lstCarta[1].valorCarta == 3)
                        playerUm.Pontos += 1;
                    if (lstCarta[2].valorCarta == 3)
                        playerUm.Pontos += 1;

                    //cartao amarelo
                    if (lstCarta[0].valorCarta == 4)
                        playerUm.Pontos += 1;
                    if (lstCarta[1].valorCarta == 4)
                        playerUm.Pontos += 1;
                    if (lstCarta[2].valorCarta == 4)
                        playerUm.Pontos += 1;

                    if (lstCarta[0].valorCarta == 6)
                        playerUm.Pontos += 2;
                    if (lstCarta[1].valorCarta == 6)
                        playerUm.Pontos += 2;
                    if (lstCarta[2].valorCarta == 6)
                        playerUm.Pontos += 2;
                }


                //else
                //{
                //    for (int i = 0; i < lstCarta.Count; i++)
                //    {

                //        if (lstCarta[0].valorCarta == 1 || lstCarta[1].valorCarta == 1 || lstCarta[2].valorCarta == 1)//gol
                //        {
                //            playerUm.Energia += 3;
                //        }
                //        else if (lstCarta[0].valorCarta == 2 || lstCarta[1].valorCarta == 2 || lstCarta[2].valorCarta == 2)//penalti
                //        {
                //            playerUm.Energia += 2;

                //        }
                //        else if (lstCarta[0].valorCarta == 3 || lstCarta[1].valorCarta == 3 || lstCarta[2].valorCarta == 3)//falta
                //        {
                //            playerUm.Energia++;
                //        }
                //        else if (lstCarta[0].valorCarta == 4 || lstCarta[1].valorCarta == 4 || lstCarta[2].valorCarta == 4)//cartao amarelo
                //        {
                //            playerUm.Energia++;
                //        }
                //        else if (lstCarta[0].valorCarta == 5 || lstCarta[1].valorCarta == 5 || lstCarta[2].valorCarta == 5)//cartao vermelho
                //        {
                //            playerUm.Energia += 0;
                //        }
                //        else if (lstCarta[0].valorCarta == 6 && lstCarta[1].valorCarta == 6 && lstCarta[2].valorCarta == 6)
                //        {
                //            playerUm.Energia -= 2;
                //        }
                //    }
                   
                //}

            }
            else
            {
                Console.WriteLine("Quem irá começar será {0}", playerdois.Nome.ToUpper());
                Console.WriteLine();
            }
            Console.Clear();
            playerUm.Painel(playerUm, playerdois);

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