using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class CadUsuarios
    {
        private Nodo _primeiro;

        internal void Adicionar(Usuario usuario)
        {
            Nodo aux = new Nodo(usuario);
            if (_primeiro == null)
            {
                _primeiro = aux;
            }
            else
            {
                Nodo atual = _primeiro;
                while (atual.Prox != null)
                {
                    atual = atual.Prox;

                }
                atual.Prox = aux;
            }
        }
        internal int Tamanho()
        {
            if (_primeiro == null)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return 0;
            }
            Nodo aux = _primeiro;
            int p = 1;
            while (aux.Prox != null)
            {
                aux = aux.Prox;
                p++;
            }
            return p;
        }
        internal Usuario Busca(int num)
        {
            Nodo nodo = _primeiro;
            if (_primeiro == null)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return null;
            }
            int p = 1;
            do
            {
                if (p == num)
                {


                    return nodo.Valor;
                }
                else
                {
                    nodo = nodo.Prox;
                    p++;
                }
            } while (nodo != null);
            return null;
        }
        internal void Remover(string item)
        {
            Nodo nodo = _primeiro;
            if (_primeiro == null)
            {
                return;
            }
            if (_primeiro.Valor.Matricula == item)
            {
                _primeiro = _primeiro.Prox;

            }
            else
            {
                do
                {
                    if (nodo.Prox.Valor.Matricula == item)
                    {
                        nodo.Prox = nodo.Prox.Prox;
                        return;
                    }
                    else
                    {
                        nodo = nodo.Prox;
                    }

                } while (nodo != null);

                return;

            }
        }
        internal Usuario Confere(string item)
        {
            Nodo nodo = _primeiro;
            if (_primeiro == null)
            {

                return null;
            }
            if (_primeiro.Valor.Matricula == item)
            {
                return _primeiro.Valor;

            }
            else
            {
                do
                {
                    if (nodo.Valor.Matricula == item)
                    {

                        return nodo.Valor;
                    }
                    else
                    {
                        nodo = nodo.Prox;
                    }

                } while (nodo != null);

                return null;
            }
        }

        internal void listar()
        {
            Nodo nodo = _primeiro;
            if (nodo == null)
            {
                Console.WriteLine("nenhum usuário cadastrado");
                return;
            }
            do
            {
                Console.WriteLine(nodo);
                nodo = nodo.Prox;
            }
            while (nodo != null);
        }


    }
}
