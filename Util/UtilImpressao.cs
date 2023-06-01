using GolDePlaca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GolDePlaca.Util
{
    public class UtilImpressao
    {
        public static int Opcao { get; set; }

        public static void ModoDeJogo(Player playerUm, Player playerdois)
        {
            //int opcao;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0,0}", "                                       ╔══════════════════════════════════════════╗                                    "));
            Console.WriteLine(string.Format("{0,0}", "    ###     ###    ###    ###   #      ║                ####    #####             ║  ####   #       ###    ####   ###  "));
            Console.WriteLine(string.Format("{0,0}", "   #   #   #   #  #   #  #   #  #      ║                #   #   #                 ║  #   #  #      #   #  #      #   # "));
            Console.WriteLine(string.Format("{0,0}", "   #       #   #  #   #  #   #  #      ║                #   #   ####              ║  ####   #      #   #  #      #   # "));
            Console.WriteLine(string.Format("{0,0}", "   #  -#   #   #  #   #  #   #  #      ║                #   #   #                 ║  #      #      # # #  #      # # # "));
            Console.WriteLine(string.Format("{0,0}", "    ###     ###    ###    ###   #####  ║                ####    #####             ║  #      #####  #   #   ####  #   # "));
            Console.WriteLine(string.Format("{0,0}{1,80}", "_______________________________________║", "║_____________________________________"));
            Console.WriteLine("\nVamos Jogar?");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(string.Format("\n{0,30}", "╔════════════════════════╗"));
            Console.WriteLine(string.Format("{0,30}", "║═ESCOLHA SEU ADVERSARIO═║"));
            Console.WriteLine(string.Format("{0,30}", "╬══════╬═════════════════╬"));
            Console.WriteLine(string.Format("{0,30}", "║ Opção║                 ║"));
            Console.WriteLine(string.Format("{0,30}", "╬══════╬═════════════════╬"));
            Console.WriteLine(string.Format("{0,30}", "║  1   ║ Single Player   ║"));
            Console.WriteLine(string.Format("{0,30}", "║  2   ║ MultiPlayer     ║"));
            Console.WriteLine(string.Format("{0,30}", "╬══════╬═════════════════╬"));
            Console.Write("\n--> ");
            Opcao = int.Parse(Console.ReadLine());

            do
            {
                if (OpcaoInvalida(Opcao))
                {
                    Console.WriteLine("Opção Invalida... Tente novamente.");
                    Console.WriteLine("\nVamos Jogar?");
                    Console.Write("\n--> ");
                    Opcao = int.Parse(Console.ReadLine());
                }
            } while (OpcaoInvalida(Opcao));
            Console.Write("\nDigite o nome do primeiro jogador\r\n--> ");
            playerUm.Nome = Console.ReadLine();

            Console.WriteLine();

            if (Opcao == 1)
            {
                playerdois.Nome = "PELE";
                Console.Clear();
                Console.WriteLine("{0} Vs {1}", playerUm.Nome.ToUpper(), playerdois.Nome.ToUpper());
            }
            else if (Opcao == 2)
            {
                Console.Write("Digite o nome do segundo jogador\r\n--> ");
                playerdois.Nome = Console.ReadLine();
                Console.WriteLine();

                Console.Clear();
                Console.WriteLine("{0} Vs {1}", playerUm.Nome.ToUpper(), playerdois.Nome.ToUpper());
            }

        }
        public static bool OpcaoInvalida(int opcao)
        {
            //if (!(Int32.TryParse(opcao.ToString(), out opcao)))
            //{
            //    string msg = "Não digite letras, apenas números";
            //    ApplicationException e = new ApplicationException(msg);
            
            //}    throw e;

            return opcao <= 0 || opcao >= 3;
        }

        public static void Placar(Player objplayerUm, Player objplayerDois)
        {
            Console.WriteLine("╬═══════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=═══════════╬");
            Console.WriteLine("║Tabela de Pontos");
            Console.WriteLine("║1 – Gol – 3 pontos,\r\n║2 – Pênalti – 2 pontos,\r\n║3 – Falta – 1 ponto,\r\n║4 - Cartão Amarelo – 1 ponto,\r\n║5 - Cartão Vermelho – 0 pontos,\r\n║6 – Energia - 2 pontos.");
            Console.WriteLine("╬═══════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=═══════════╬");
            Console.Write("║Energia de {0} : {1}   Gol : {2}   Pontuação : {3}", objplayerUm.Nome.ToUpper(), objplayerUm.Energia, objplayerUm.Gol, objplayerUm.Pontos);
            Console.WriteLine("                  Energia de {0} : {1}   Gol : {2}   Pontuação : {3}", objplayerDois.Nome.ToUpper(), objplayerDois.Energia, objplayerDois.Gol, objplayerDois.Pontos);
            Console.WriteLine("╬═══════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=═══════════╬");
        }
        public static void Escolha()
        {
            Console.WriteLine("\n\nAgora é sua vez, faça o melhor!");
            Console.WriteLine("");
            Console.WriteLine(string.Format("\n{0,30}", "╔════════════════════════╗"));
            Console.WriteLine(string.Format("{0,30}", "║     ESCOLHA UM LADO    ║"));
            Console.WriteLine(string.Format("{0,30}", "╬══════╬═════════════════╬"));
            Console.WriteLine(string.Format("{0,30}", "║ Opção║                 ║"));
            Console.WriteLine(string.Format("{0,30}", "╬══════╬═════════════════╬"));
            Console.WriteLine(string.Format("{0,30}", "║  1   ║ Direita         ║"));
            Console.WriteLine(string.Format("{0,30}", "║  2   ║ Centro          ║"));
            Console.WriteLine(string.Format("{0,30}", "║  3   ║ Esquerda        ║"));
            Console.WriteLine(string.Format("{0,30}", "╬══════╬═════════════════╬"));
            Console.Write("\n--> ");
        } 

        public static void Gol()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format("{0,80}", "╔══════════════════════════════════════════╗"));
            Console.WriteLine(string.Format("{0,80}", "║                                          ║"));
            Console.WriteLine(string.Format("{0,80}", "║     ###     ###    ###    ###   #        ║"));
            Console.WriteLine(string.Format("{0,80}", "║    #       #   #  #   #  #   #  #        ║"));
            Console.WriteLine(string.Format("{0,80}", "║    #  -#   #   #  #   #  #   #  #        ║"));
            Console.WriteLine(string.Format("{0,80}", "║     ###     ###    ###    ###   #####    ║"));
            Console.WriteLine(string.Format("{0,0}{1,83}", "____________________________________║", "║________________________________________"));
            Console.WriteLine();

            Console.WriteLine(string.Format("\n{0,76}", "BOLA PARA UM LADO GOLEIRO PARA O OUTRO"));

            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.gol);
            soundPlayer.Play(); // Para começar o som normalmente.
                                
            Console.ReadKey();
            soundPlayer.Stop();
            SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.fut);
            soundPlayer1.PlayLooping(); // Para começar o som e ficar repetindo.                                        
        }

        public static void DefesaPenalti()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format("{0,80}", "╔══════════════════════════════════════════╗"));
            Console.WriteLine(string.Format("{0,80}", "║    ###   ####  ####  ####  ####  ####    ║"));
            Console.WriteLine(string.Format("{0,80}", "║    #  #  #     #     #     #     #  #    ║"));
            Console.WriteLine(string.Format("{0,80}", "║    #  #  ####  ###   ####  ####  ####    ║"));
            Console.WriteLine(string.Format("{0,80}", "║    #  #  #     #     #        #  #  #    ║"));
            Console.WriteLine(string.Format("{0,80}", "║    ###   ####  #     ####  ####  #  #    ║"));
            Console.WriteLine(string.Format("{0,0}{1,83}", "____________________________________║", "║________________________________________"));
            Console.WriteLine();

            Console.WriteLine(string.Format("\n{0,70}", "VAI QUE É SUA TAFAREL!!!"));

            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.tafarel);
            soundPlayer.Play(); // Para começar o som normalmente.
                               
            Console.ReadKey();
            soundPlayer.Stop();
            SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.fut);
            soundPlayer1.PlayLooping(); // Para começar o som e ficar repetindo.
        }

        public static void CartaoAmarelo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine(string.Format("{0,70}", "CARTÃO AMARELO"));
            Console.WriteLine(string.Format(@"{0,90}", "\r\n                   ,▄███████████████████████\r\n                   ██ ░   ░                ██\r\n                   ██    CARTÃO AMARELO    ██\r\n                   ██ ░                    ██\r\n                   ██                      ██\r\n                   ██                      ██\r\n                   ██                      ██\r\n                   ██       ▄██▀▀██▄       ██\r\n                   ██      ▐█      █▌      ██\r\n                   ██      ▐█      █▌      ██\r\n                ╔████      ▐█      █▌      ██\r\n              ▄█▀  ██      ▐█      █▌      ██\r\n             ▐█    ██      ▐█      █▌      ██\r\n             ██    ██      ▐█      ██      ██\r\n             ██    ██      ▐█      '█▄     ██\r\n             ██     ▀████████        ▀█████▀\r\n             ██            ▐█          ▀█▄\r\n             ██                          █▌\r\n              ██                         ▐█\r\n               ╙█▄                       ▐█\r\n                 ╙█▄                     ██\r\n                   ╙█▄,               ,▄█▀\r\n                      ▀▀▀███████████▀▀▀`"));
            

            SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.yellow);
            soundPlayer1.Play(); // Para começar o som normalmente.

            Console.ReadKey();
            soundPlayer1.Stop();

            SoundPlayer soundPlayer2 = new SoundPlayer(Properties.Resources.fut);
            soundPlayer2.PlayLooping(); // Para começar o som e ficar repetindo.
        }

        public static void CartaoVermelho()
        {
            //Console.WriteLine(string.Format("{0,70}", "CARTÃO VERMELHO"));
            Console.WriteLine(string.Format(@"{0,90}", "\r\n                   ,▄███████████████████████\r\n                   ██ ░   ░                ██\r\n                   ██    CARTÃO VERMELHO   ██\r\n                   ██ ░                    ██\r\n                   ██                      ██\r\n                   ██                      ██\r\n                   ██                      ██\r\n                   ██       ▄██▀▀██▄       ██\r\n                   ██      ▐█      █▌      ██\r\n                   ██      ▐█      █▌      ██\r\n                ╔████      ▐█      █▌      ██\r\n              ▄█▀  ██      ▐█      █▌      ██\r\n             ▐█    ██      ▐█      █▌      ██\r\n             ██    ██      ▐█      ██      ██\r\n             ██    ██      ▐█      '█▄     ██\r\n             ██     ▀████████        ▀█████▀\r\n             ██            ▐█          ▀█▄\r\n             ██                          █▌\r\n              ██                         ▐█\r\n               ╙█▄                       ▐█\r\n                 ╙█▄                     ██\r\n                   ╙█▄,               ,▄█▀\r\n                      ▀▀▀███████████▀▀▀`"));
            Console.WriteLine("\nPASSOU A VEZ!");

            SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.red);
            soundPlayer1.Play(); // Para começar o som normalmente.
                               
            Console.ReadKey();
            soundPlayer1.Stop();

            SoundPlayer soundPlayer2 = new SoundPlayer(Properties.Resources.fut);
            soundPlayer2.PlayLooping(); // Para começar o som e ficar repetindo.
        }

        public static void Energia()
        {
            Console.WriteLine(string.Format("\n{0,74}", "VOCÊ GANHOU UMA ENERGIA"));
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"
                                        ██████████████████████████████████████████████
                                        ██████████████████████████████████████████████
                                        ████                                      ▐███
                                        ████    ███▌     ▐███      ████           ▐███████
                                        ████    ███▌     ▐███      ████           ▐███████
                                        ████    ███▌     ▐███      ████           ▐███████
                                        ████    ███▌     ▐███      ████           ▐███████
                                        ████    ███▌     ▐███      ████           ▐███████
                                        ████    ███▌     ▐███      ████           ▐███████
                                        ████                                      ▐███▀▀▀▀
                                        ████                                      ▐███
                                        ██████████████████████████████████████████████
    
");
            Console.WriteLine("\n\n\n\n  PASSE A VEZ");

            SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.energy);
            soundPlayer1.Play(); // Para começar o som normalmente.
                                 
            Console.ReadKey();
            soundPlayer1.Stop();

            SoundPlayer soundPlayer2 = new SoundPlayer(Properties.Resources.fut);
            soundPlayer2.PlayLooping(); // Para começar o som e ficar repetindo.
        }
        public static void Campeao(Player player) {
            Console.WriteLine(string.Format("{0,71}", "Parabéns " + player.Nome.ToUpper() + " você é o CAMPEÃO"));
            Console.WriteLine(string.Format("{0,75}", "──────────────█████████████─────────────"));
            Console.WriteLine(string.Format("{0,75}", "───────────███████████████████──────────"));
            Console.WriteLine(string.Format("{0,75}", "────────████████████████████████────────"));
            Console.WriteLine(string.Format("{0,75}", "█████████─████████████████████─█████████"));
            Console.WriteLine(string.Format("{0,75}", "███───────████████────████████───────███"));
            Console.WriteLine(string.Format("{0,75}", "███───────██████───██───██████───────███"));
            Console.WriteLine(string.Format("{0,75}", "─███──────█████──████────█████──────███─"));
            Console.WriteLine(string.Format("{0,75}", "──███─────████─────██─────████─────███──"));
            Console.WriteLine(string.Format("{0,75}", "───███────████─────██─────████────███───"));
            Console.WriteLine(string.Format("{0,75}", "────███───█████────██────█████───███────"));
            Console.WriteLine(string.Format("{0,75}", "─────███──█████────██────█████──███─────"));
            Console.WriteLine(string.Format("{0,75}", "──────███─███████──────███████─███──────"));
            Console.WriteLine(string.Format("{0,75}", "───────██─████████████████████─██───────"));
            Console.WriteLine(string.Format("{0,75}", "────────█─████████████████████─█────────"));
            Console.WriteLine(string.Format("{0,75}", "───────────██████████████████───────────"));
            Console.WriteLine(string.Format("{0,75}", "─────────────██████████████─────────────"));
            Console.WriteLine(string.Format("{0,75}", "───────────────███████████──────────────"));
            Console.WriteLine(string.Format("{0,75}", "────────────────█████████───────────────"));
            Console.WriteLine(string.Format("{0,75}", "──────────────█████████████─────────────"));

        }
        public static void Final(Player objplayerUm, Player objplayerDois)
        {
            Console.WriteLine("╬═══════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=═══════════╬");
            Console.WriteLine("║               ####   #      #####  #####  #####  ####            #####  ###  ##    #  #####  #                       ║");
            Console.WriteLine("║               #   #  #      #   #  #      #   #  #   #           #       #   # #   #  #   #  #                       ║");
            Console.WriteLine("║               ####   #      #####  #      #####  ####            #####   #   #  #  #  #####  #                       ║");
            Console.WriteLine("║               #      #      #   #  #      #   #  ###_            #       #   #   # #  #   #  #                       ║");
            Console.WriteLine("║               #      #####  #   #  #####  #   #  #   #           #      ###  #    ##  #   #  #####                   ║");
            Console.WriteLine("╬═══════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=═══════════╬");
            Console.Write("║Energia de {0} : {1}   Gol : {2}   Pontuação : {3}", objplayerUm.Nome.ToUpper(), objplayerUm.Energia, objplayerUm.Gol, objplayerUm.Pontos);
            Console.WriteLine("                  Energia de {0} : {1}   Gol : {2}   Pontuação : {3}", objplayerDois.Nome.ToUpper(), objplayerDois.Energia, objplayerDois.Gol, objplayerDois.Pontos);
            Console.WriteLine("╬═══════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=══════════=═══════════╬");
        }

        public static void Integrantes()
        {
            Console.WriteLine(@"                                                 -------------------
                                                  My World Cup Team
                                                 -------------------
                                                                                     CESAR
                                                                                    FERREIRA

                              IASMINE      ÉDER     FLAVIO      LUCAS      RAFAEL      ,/)
                                                                                       |_|
                                 _          _          _          _          _         ].[
                                |.|        |.|        |.|        |.|        |.|      /~`-'~\
                                ]^[        ]^[        ]^[        ]^[        ]^[     (<|%  |>)
                              /~`-'~\    /~`-'~\    /~`-'~\    /~`-'~\    /~`-'~\    \|___|/
                             {<|%  |>}  {<|%  |>}  {<|%  |>}  {<|%  |>}  {<|%  |>}   {/   \}
                              \|___|/    \|___|/    \|___|/    \|___|/    \|___|/    /__|__\
                             /\    \      /   \      /   \      /   \      /   \     | / \ |
                             |/>/|__\    /__|__\    /__|__\    /__|__\    /__|__\    |/   \|
                            _|)   \ |    | / \ |    | / \ |    | / \ |    | / \ |    {}   {}
                           (_,|    \)    (/   \)    (/   \)    (/   \)    (/   \)    |)   (|
                           / \     (|_  _|)   (|_  _|)   (|_  _|)   (|_  _|)   (|_  _||   ||_
                        .,.\_/,...,|,_)(_,|,.,|,_)(_,|,.,|,_)(_,|,.,|,_)(_,|,.,|,_)(_,|.,.|,_).,.");
        }
       
    }
}
//exeplos de iplementação de audio

//SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.fut);
//soundPlayer.Play(); // Para começar o som normalmente.
//soundPlayer.PlayLooping(); // Para começar o som e ficar repetindo.
//soundPlayer.PlaySync(); // Para começar o som e só ir para a próxima linha quando parar de tocar.
