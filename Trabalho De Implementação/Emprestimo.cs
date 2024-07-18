using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Emprestimo
    {
		private int identificacao;
		private Usuario usuario;
		private ItemBiblioteca item;
		private DateTime dataEmprestimo;
		private DateTime dataDevolucao;

		public DateTime DataDevolucao
		{
			get { return dataDevolucao; }
			set { dataDevolucao = value; }
		}


		public DateTime DataEmprestimo
		{
			get { return dataEmprestimo; }
			set { dataEmprestimo = value; }
		}


		public ItemBiblioteca Item
		{
			get { return item; }
			set { item = value; }
		}


		public Usuario Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}


		public int Identificacao
		{
			get { return identificacao; }
			set { identificacao = value; }
		}

        public Emprestimo(int identificacao, Usuario usuario, ItemBiblioteca item, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            this.identificacao = identificacao;
            this.usuario = usuario;
            this.item = item;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
        }
		public Emprestimo() { }

		public void Emprestar (Usuario usr, ItemBiblioteca item, int prazo)
		{
			bool aux = usr.Emprestimo();
			if (aux == true)
			{
				Console.WriteLine("O usuário já tem um empréstimo.");
				return;
			}
			if (item.Situacao != SituacaoItem.Disponivel)
			{
				
                Console.WriteLine("o item não está disponivel.");
				return;

            } 
			DateTime dataDevol = DateTime.Now.AddDays(prazo);
            this.usuario = usr;
            this.item = item;
            this.dataEmprestimo = DateTime.Now;
            this.dataDevolucao = dataDevol;
			usr.EmprestimoAtual=true; 
        }
		public void Retornar()
		{
			usuario.EmprestimoAtual = false;
            usuario = null;
            item.Situacao = SituacaoItem.Disponivel;
            item = null;
            dataEmprestimo = DateTime.MinValue;
            dataDevolucao = DateTime.MinValue;
			
			
        }

        public override string ToString()
        {
            return identificacao + ";" + usuario + ";" + item + ";" + dataEmprestimo + ";" + dataDevolucao;
        }
    }
}
