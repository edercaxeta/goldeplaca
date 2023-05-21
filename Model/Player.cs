using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolDePlaca.Model
{
    public class Player
    {
        public string Nome { get; set; }
        public int Energia { get; set; }
        public int Gol { get; set; }
        public int Pontos { get; set; }
        public bool JaTemCartaoAmarelo { get; set; }

        public Player()
        {
            Energia = 10;
            Gol = 0;
            Pontos = 0;
        }

        public void AtualizarPontos()
        {

        }
    }
}
