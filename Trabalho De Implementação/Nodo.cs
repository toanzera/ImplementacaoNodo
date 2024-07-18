using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Nodo
    {
        public Usuario Valor { get; set; }
        public Nodo Prox { get; set; }

        

        public Nodo(Usuario valor)
        {

            Valor = valor;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}
