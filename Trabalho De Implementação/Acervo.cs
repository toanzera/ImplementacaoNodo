using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Acervo
    {
        private NodoAc _primeiro;

        internal void Adicionar(ItemBiblioteca item)
        {
            NodoAc aux = new NodoAc(item);
            if (_primeiro == null)
            {
                _primeiro = aux;
            }
            else
            {
                NodoAc atual = _primeiro;
                while(atual.Prox != null)
                {
                    atual = atual.Prox;

                } 
                atual.Prox = aux;
            }
        }
        internal int Tamanho()
        {
            if (_primeiro== null)
            {
                Console.WriteLine("Nenhum item na biblíoteca.");
                return 0;
            }
            NodoAc aux = _primeiro;
            int p = 1;
            while (aux.Prox != null)
            {
                aux = aux.Prox;
                p++;
            }
            return p;
        }
        internal ItemBiblioteca Busca(int num)
        {
            NodoAc nodo = _primeiro;
            if (_primeiro == null)
            {
                Console.WriteLine("Nenhum item na bibliotéca.");
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
        internal void Remover(int item)
        {
            NodoAc nodo = _primeiro;
            if (_primeiro == null)
            {
                return;
            }
            if (_primeiro.Valor.Identificacao == item)
            {
                _primeiro = _primeiro.Prox;

            }
            else
            {
                do
                {
                    if (nodo.Prox.Valor.Identificacao == item)
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

        internal ItemBiblioteca Confere(int auxItem)
        {
            NodoAc nodo = _primeiro;
            if (_primeiro == null)
            {

                return null;
            }
            if (_primeiro.Valor.Identificacao == auxItem)
            {
                return _primeiro.Valor;

            }
            else
            {
                do
                {
                    if (nodo.Valor.Identificacao == auxItem)
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

        internal void ListarLivros()
        {
            NodoAc nodo = _primeiro;
            if (nodo == null)
            {
                Console.WriteLine("nenhum Livro registrado cadastrado");
                return;
            }
            do
            {
                if (nodo.Valor is Livro)
                {
                    Console.WriteLine(nodo);
                }
                nodo = nodo.Prox;
            }
            while (nodo != null);
        }

        internal void ListarPeriodicos()
        {
            NodoAc nodo = _primeiro;
            if (nodo == null)
            {
                Console.WriteLine("nenhum periódico registrado cadastrado");
                return;
            }
            do
            {
                if (nodo.Valor is Periodico)
                {
                    Console.WriteLine(nodo);
                }
                nodo = nodo.Prox;
            }
            while (nodo != null);
        }

        internal void ListarDvd()
        {
            NodoAc nodo = _primeiro;
            if (nodo == null)
            {
                Console.WriteLine("nenhum DVD registrado cadastrado");
                return;
            }
            do
            {
                if (nodo.Valor is DVD)
                {
                    Console.WriteLine(nodo);
                }
                nodo = nodo.Prox;
            }
            while (nodo != null);
        }
        
    }
}
    