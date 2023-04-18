using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolDePlaca
{
    public class Player
    {
        public string Nome{ get; set; }
        public int Energia { get; set; }
        public int Gol { get; set; }
        public int Pontos { get; set; }
        

        public void Painel(Player objplayerUm, Player objplayerDois)
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Tabela de Pontos");
            Console.WriteLine("1 – Gol – 3 pontos,\r\n2 – Pênalti – 2 pontos,\r\n3 – Falta – 1 ponto,\r\n4 - Cartão Amarelo – 1 ponto,\r\n5 - Cartão Vermelho – 0 pontos,\r\n6 – Energia - 2 pontos.");
            //Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.Write    ("|Emergia de {0} : {1}%   Gol : {2}   Pontuação : {3}", objplayerUm.Nome.ToUpper(), objplayerUm.Energia, objplayerUm.Gol,objplayerUm.Pontos);
            Console.WriteLine("                      Emergia de {0} : {1}%   Gol : {2}   Pontuação : {3}",objplayerDois.Nome.ToUpper(), objplayerDois.Energia, objplayerDois.Gol,objplayerDois.Pontos);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
