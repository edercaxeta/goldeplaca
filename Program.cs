using GolDePlaca.Model;
using GolDePlaca.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;

namespace GolDePlaca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.fut);
            soundPlayer.PlayLooping(); // Para começar o som e ficar repetindo.
            
            Player playerUm, playerdois;

            int saida = 0;

            while (saida == 0)
            {
                //Função para inicializar os objetos
                InicializaObj(out playerUm, out playerdois);

                //modo do jogo(Função de escolha)
                UtilImpressao.ModoDeJogo(playerUm, playerdois);

                //Placar de energia
                Console.Clear();
                UtilImpressao.Placar(playerUm, playerdois);


                //Sorteio de quem irá começar
                Random random = new Random();
                int primeiroAJogar = random.Next(1, 3);


                while (playerUm.Energia > 0 || playerdois.Energia > 0)
                {

                    if (primeiroAJogar == 1)
                    {
                        //começa pelo playerum
                        if (playerUm.Energia > 0)
                        {
                            ExecutarJogada(playerUm);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            UtilImpressao.Placar(playerUm, playerdois);
                        }
                        if (playerdois.Energia > 0)
                        {
                            ExecutarJogada(playerdois);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            UtilImpressao.Placar(playerUm, playerdois);
                        }
                    }
                    else
                    {
                        //começa pelo playerdois
                        if (playerdois.Energia > 0)
                        {
                            ExecutarJogada(playerdois);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            UtilImpressao.Placar(playerUm, playerdois);
                        }

                        if (playerUm.Energia > 0)
                        {
                            ExecutarJogada(playerUm);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            UtilImpressao.Placar(playerUm, playerdois);
                        }
                    }

                }
                Console.Clear();

                //Verifica se há um campeão
                if (playerUm.Gol > playerdois.Gol && playerUm.Energia == 0 && playerdois.Energia == 0)

                {
                    UtilImpressao.Final(playerUm,playerdois);
                    UtilImpressao.Campeao(playerUm);
                                    }
                else if (playerUm.Gol < playerdois.Gol && playerUm.Energia == 0 && playerdois.Energia == 0)
                {
                    UtilImpressao.Final(playerUm, playerdois);
                    UtilImpressao.Campeao(playerdois);
                }
                //Verifica se há empate
                else if (playerUm.Gol == playerdois.Gol && playerUm.Energia == 0 && playerdois.Energia == 0)
                {
                    if (playerUm.Pontos > playerdois.Pontos)
                    {
                        UtilImpressao.Final(playerUm, playerdois);
                        UtilImpressao.Campeao(playerUm);
                    }
                    else if (playerUm.Pontos < playerdois.Pontos)
                    {
                        UtilImpressao.Final(playerUm, playerdois);
                        UtilImpressao.Campeao(playerdois);
                    }
                    //empate de pontuação
                    else
                    {
                        //sorteio do campeao caso de empate em todos os criterios
                        Console.WriteLine("Empate na pontuação, o critério aplicado para\n definir o ganhador será: ALEATÓRIO");
                        Random rnd = new Random();
                        int ganhadorAleatorio = rnd.Next(1, 3);
                        switch (ganhadorAleatorio)
                        {
                            case 1:
                                UtilImpressao.Final(playerUm, playerdois);
                                UtilImpressao.Campeao(playerUm);
                                break;
                            case 2:
                                UtilImpressao.Final(playerUm, playerdois);
                                UtilImpressao.Campeao(playerdois);
                                break;
                            default:
                                Console.WriteLine("Algo inesperado aconteceu!");
                                break;
                        }
                    }
                }

                SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.acabou);
                soundPlayer1.Play(); // Para começar o som normalmente.
                                    
                Console.ReadKey();
                soundPlayer.Stop();
                SoundPlayer soundPlayer2 = new SoundPlayer(Properties.Resources.fut);
                soundPlayer2.PlayLooping(); // Para começar o som e ficar repetindo.
                                            
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("\nDigite “-1” para sair, ou digite “0” para uma nova partida");
                saida = int.Parse(Console.ReadLine());

                while (saida != 0 && saida != -1)
                {
                    Console.WriteLine("Opção invalida, Repita!");
                    saida = int.Parse(Console.ReadLine());
                }
                Console.Clear() ;
            }

            UtilImpressao.Integrantes();
            Console.WriteLine(string.Format("\n\n\n\n\n{0,68}", "POO II TURMA:2023 "));
            Console.ReadLine();
        }



        private static void InicializaObj(out Player playerUm, out Player playerdois)
        {
            playerUm = new Player();
            playerdois = new Player();
        }

        private static void ExecutarJogada(Player player)
        {
            InicializaObj(out Player playerUm, out Player playerdois);
            Console.WriteLine(string.Format("\n{0,75}", "Quem jogará agora é o " + player.Nome.ToUpper()));
            Console.WriteLine();


            List<Carta> cartasDaVez = new List<Carta>();

            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nAperte enter para escolher a {0}ª carta:", i + 1);
                Console.ReadKey();
                cartasDaVez.Add(UtilCartas.SortearCarta());
            }
            Console.ReadKey(true);
            
            //Gol
            if (cartasDaVez.All(carta => carta.Numero == 1))
            {
                Console.Clear();
                UtilImpressao.Gol();
                player.Gol++;

            }

            //Pênalti
            else if (cartasDaVez.All(carta => carta.Numero == 2))
            {
                int[] opcaoPenalti = new int[2];
                switch (UtilImpressao.Opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;

                        Console.WriteLine("\nPênalidade Maxima, o Juiz não exitou e marcou o Penalti!!");

                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.penalty);
                        soundPlayer.Play(); // Para começar o som normalmente.
                                           
                        Console.ReadKey();
                        soundPlayer.Stop();
                        SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.fut);
                        soundPlayer1.PlayLooping(); // Para começar o som e ficar repetindo.
                                                  
                        Console.ReadKey(true);
                        Console.Clear();

                        Random random = new Random();
                        int primeiroAJogar = random.Next(1, 3);
                        if (primeiroAJogar == 1)
                        {
                            Console.WriteLine(string.Format("{0,80}", "QUEM VAI COMEÇAR É O " + player.Nome.ToUpper()));
                            for (int i = 0; i < 3; i++)
                            {
                                //Vez do jogadorUm
                                if (i == 0)
                                {
                                    UtilImpressao.Escolha();
                                    int op = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                //Vez do PELE
                                if (i == 1)
                                {
                                    UtilImpressao.Escolha();
                                    Random rand = new Random();
                                    int ladoAleatorio = rand.Next(1, 4);
                                    opcaoPenalti[i] = ladoAleatorio;
                                    Console.WriteLine("PELÉ FEZ SUA ESCOLHA!");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                if (i == 2)
                                {
                                    if (opcaoPenalti[0] == opcaoPenalti[1])
                                    {
                                        UtilImpressao.DefesaPenalti();
                                    }
                                    else
                                    {
                                        UtilImpressao.Gol();
                                        player.Gol++;
                                    }
                                }
                            }

                        }
                        else if(primeiroAJogar == 2)
                        {
                            Console.WriteLine(string.Format("{0,80}", "QUEM VAI COMEÇAR É O " + player.Nome.ToUpper()));
                            for (int i = 0; i < 3; i++)
                            {
                                //Vez de PELE
                                if (i == 0)
                                {
                                    UtilImpressao.Escolha();
                                    Random rand = new Random();
                                    int ladoAleatorio = rand.Next(1, 4);
                                    opcaoPenalti[i] = ladoAleatorio;
                                    Console.WriteLine("PELÉ FEZ SUA ESCOLHA!");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                //Vez do jogadorUm
                                if (i == 1)
                                {
                                    UtilImpressao.Escolha();
                                    int op = int.Parse(Console.ReadLine());
                                    opcaoPenalti[i] = op;
                                    Console.Clear();
                                }
                                if (i == 2)
                                {
                                    if (opcaoPenalti[0] == opcaoPenalti[1])
                                    {
                                        UtilImpressao.DefesaPenalti();
                                    }
                                    else
                                    {
                                        UtilImpressao.Gol();
                                        player.Gol++;
                                    }
                                }
                            }
                        }

                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Magenta;

                        Console.WriteLine("\nPênalidade Maxima, o Juiz não exitou e marcou o Penalti!!");

                        SoundPlayer soundPlayer3 = new SoundPlayer(Properties.Resources.penalty);
                        soundPlayer3.Play(); // Para começar o som normalmente.
                                           
                        Console.ReadKey();
                        soundPlayer3.Stop();
                        SoundPlayer soundPlayer4 = new SoundPlayer(Properties.Resources.fut);
                        soundPlayer4.PlayLooping(); // Para começar o som e ficar repetindo.
                                                   
                        Console.ReadKey(true);
                        Console.Clear();

                        Random rnd = new Random();
                        int Primeiro = rnd.Next(1, 3);
                        if (Primeiro == 1)
                        {
                            Console.WriteLine(string.Format("{0,80}", "QUEM VAI COMEÇAR É O " + player.Nome.ToUpper())); Console.WriteLine(string.Format("{0,80}", "O " + player.Nome.ToUpper()));
                            for (int i = 0; i < 3; i++)
                            {
                                //Vez do jogadorUm
                                if (i == 0)
                                {
                                    UtilImpressao.Escolha();
                                    int op = int.Parse(Console.ReadLine());
                                    opcaoPenalti[i] = op;
                                    Console.Clear();
                                }
                                //Vez do jogadordois
                                if (i == 1)
                                {
                                    UtilImpressao.Escolha();
                                    int op = int.Parse(Console.ReadLine());
                                    opcaoPenalti[i] = op;
                                    Console.Clear();
                                }
                                if (i == 2)
                                {
                                    if (opcaoPenalti[0] == opcaoPenalti[1])
                                    {
                                        UtilImpressao.DefesaPenalti();
                                    }
                                    else
                                    {
                                        UtilImpressao.Gol();
                                        player.Gol++;
                                    }
                                }
                            }

                        }
                        else if (Primeiro == 2)
                        {
                            Console.WriteLine(string.Format("{0,80}", "QUEM VAI COMEÇAR É O " + player.Nome.ToUpper()));
                            for (int i = 0; i < 3; i++)
                            {
                                //Vez do playerdois
                                if (i == 0)
                                {
                                    UtilImpressao.Escolha();
                                    int op = int.Parse(Console.ReadLine());
                                    opcaoPenalti[i] = op;
                                    Console.Clear();
                                }
                                //Vez do jogadorUm
                                if (i == 1)
                                {
                                    UtilImpressao.Escolha();
                                    int op = int.Parse(Console.ReadLine());
                                    opcaoPenalti[i] = op;
                                    Console.Clear();
                                }
                                if (i == 2)
                                {
                                    if (opcaoPenalti[0] == opcaoPenalti[1])
                                    {
                                        UtilImpressao.DefesaPenalti();
                                    }
                                    else
                                    {
                                        UtilImpressao.Gol();
                                        player.Gol++;
                                    }
                                }
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Algo deu errado!");
                        break;
                }
            }

            //Falta
            else if (cartasDaVez.All(carta => carta.Numero == 3))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" Três Faltas, PASSOU A VEZ :( ");
                SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.falta);
                soundPlayer1.Play(); // Para começar o som normalmente.
                                     
                Console.ReadKey();
                soundPlayer1.Stop();

                SoundPlayer soundPlayer2 = new SoundPlayer(Properties.Resources.fut);
                soundPlayer2.PlayLooping(); // Para começar o som e ficar repetindo.
            }

            //Cartão Amarelo
            else if (cartasDaVez.All(carta => carta.Numero == 4))
            {
                UtilImpressao.CartaoAmarelo();

                player.Energia--;
                if (player.JaTemCartaoAmarelo)
                {
                    Console.WriteLine("\n\nSEGUNDO CARTÃO SEGUIDO!!!\r\n\nPERDEU DUAS ENERGIAS");
                    player.Energia--;
                    player.JaTemCartaoAmarelo = false;
                }
                else
                {
                    Console.WriteLine("\nPERDEU UMA ENERGIA");
                    Console.WriteLine("\nALERTA!!!! Proximo sera duas ");
                    player.JaTemCartaoAmarelo = true;
                }

            }

            //Cartão Vermelho
            else if (cartasDaVez.All(carta => carta.Numero == 5))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Três Cartões Vermelho, PERDEU DUAS ENERGIA");
                player.Energia -= 2;
                Console.Clear();

                UtilImpressao.CartaoVermelho();
               
            }

            //Energia
            else if (cartasDaVez.All(carta => carta.Numero == 6))
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("\nGANHOU ENERGIA!");
                player.Energia++;
                Console.Clear();

                UtilImpressao.Energia();
            }
            else
            {
                int somaPontos = 0;
                foreach (var carta in cartasDaVez)
                {
                    somaPontos += carta.Pontuacao;
                }
                player.Pontos += somaPontos;

                Console.WriteLine(string.Format("\n\n{0,82}", $"Cartas diferentes. Você ganhou {somaPontos} pontos"));
            }
            player.Energia--;
            Console.ReadKey();
        }
    }
}

//exeplos de iplementação de audio

//SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.fut);
//soundPlayer.Play(); // Para começar o som normalmente.
//soundPlayer.PlayLooping(); // Para começar o som e ficar repetindo.
//soundPlayer.PlaySync(); // Para começar o som e só ir para a próxima linha quando parar de tocar.