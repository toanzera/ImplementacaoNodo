using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    internal class NodoEmp
    {
        public Emprestimo Valor { get; set; }
        public NodoEmp Prox { get; set; }



        public NodoEmp(Emprestimo valor)
        {

            Valor = valor;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}
 