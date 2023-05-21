using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolDePlaca.Model
{
    public class Carta
    {
        //public int valorCarta { get; set; }

        public int Numero { get; set; }
        public string Tipo { get; set; }
        public int Pontuacao { get; set; }

        public Carta(int numero, string valor, int pontuacao)
        {
            Numero = numero;
            Tipo = valor.ToUpper();
            Pontuacao = pontuacao;
        }
    }
}
