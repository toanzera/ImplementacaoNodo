using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class NodoAc
    {
        public ItemBiblioteca Valor { get; set; }
        public NodoAc Prox { get; set; }



        public NodoAc(ItemBiblioteca valor)
        {

            Valor = valor;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}

