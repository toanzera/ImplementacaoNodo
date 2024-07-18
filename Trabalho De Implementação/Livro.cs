using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Livro:ItemBiblioteca, IEmprestavel
    {
		private string autor;
		private string editora;
		private int paginas;

		public int Paginas
		{
			get { return paginas; }
			set { paginas = value; }
		}


		public string Editora
		{
			get { return editora; }
			set { editora = value; }
		}


		public string Autor
		{
			get { return autor; }
			set { autor = value; }
		}

        public Livro(int identificacao, string titulo, SituacaoItem situacao, string autor, string editora, int paginas): base(identificacao, titulo, situacao)
        {
            this.autor = autor;
            this.editora = editora;
            this.paginas = paginas;
        }
		public Livro(): base() { }

        public bool Disponivel()
        {
            return Situacao == SituacaoItem.Disponivel;
        }

        public bool Emprestado()
        {
            return Situacao == SituacaoItem.Emprestado;
        }

        public bool Bloqueado()
        {
            return Situacao == SituacaoItem.Bloqueado;
        }

        public bool Atrasado()
        {
            return Situacao == SituacaoItem.Atrasado;
        }
        public override string ToString()
        {
            string demais = base.Tostring();
            return autor + ";" + editora + ";" + paginas + ";" + demais;
        }
    }
}
