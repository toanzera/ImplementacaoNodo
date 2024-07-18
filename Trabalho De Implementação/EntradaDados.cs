using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    internal class EntradaDados
    {
        public EntradaDados()
        {
        }

        internal int LeInteiro(string texto, int min, int max)
        {
            string aux;
            int n = 0;
            bool teste;
            do
            {
                teste = true;
                Console.WriteLine(texto);
                aux = Console.ReadLine();
                if (!int.TryParse(aux, out n))
                {
                    teste = false;
                }
                if ((n < min) || (n > max))
                {
                    teste = false;
                }
                if (teste == false)
                {
                    Console.WriteLine("Entrada inválida! Digite Novamente!");
                }
            } while (teste == false);
            return n;
            
        }

        internal int LeInteiro(string texto)
        {
            string aux;
            int n = 0;
            bool teste;
            do
            {
                teste = true;
                Console.WriteLine(texto);
                aux = Console.ReadLine();
                if (!int.TryParse(aux, out n))
                {
                    teste = false;
                }
                if (teste == false)
                {
                    Console.WriteLine("Entrada inválida! Digite Novamente!");
                }
            } while (teste == false);
            return n;
        }

        internal string LeString(string texto)
        {
            string aux;
            Console.WriteLine(texto);
            aux = Console.ReadLine();
            return aux;
        }
    }
}
