using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class CadEmprestimos
    {
        private NodoEmp _primeiro;
        internal void Adicionar(Emprestimo item)
        {
            NodoEmp aux = new NodoEmp(item);
            if (_primeiro == null)
            {
                _primeiro = aux;
            }
            else
            {
                NodoEmp atual = _primeiro;
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
                Console.WriteLine("Nenhum item emprestado.");
                return 0;
            }
            NodoEmp aux = _primeiro;
            int p = 1;
            while (aux.Prox != null)
            {
                aux = aux.Prox;
                p++;
            }
            return p;
        }
        internal Emprestimo Busca(int num)
        {
            NodoEmp nodo = _primeiro;
            if (_primeiro == null)
            {
                Console.WriteLine("Nenhum item emprestado.");
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
            NodoEmp nodo = _primeiro;
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
        public void Atrasos()
        {
            if (_primeiro == null)
            {
                Console.WriteLine("Nenhum item emprestado.");
                return;
            }
            NodoEmp aux = _primeiro;
            DateTime dataAtual = DateTime.Now;
            while (aux != null)
            {
                if (aux.Valor.DataDevolucao < dataAtual)
                {
                    aux.Valor.Item.Situacao = SituacaoItem.Atrasado;
                }
                aux = aux.Prox;
            }
        }

        internal Emprestimo Confere(int item)
        {

            NodoEmp nodo = _primeiro;
            if (_primeiro == null)
            {

                return null;
            }
            if (_primeiro.Valor.Identificacao == item)
            {
                return _primeiro.Valor;

            }
            else
            {
                do
                {
                    if (nodo.Valor.Identificacao == item)
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

        internal void Listar()
        {
            NodoEmp nodo = _primeiro;
            if (nodo == null)
            {
                Console.WriteLine("nenhum Emprestimo registrado");
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
