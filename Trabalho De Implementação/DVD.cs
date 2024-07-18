using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class DVD: ItemBiblioteca, IEmprestavel
    {
		private string assunto;
		private int duracao;

		public int Duracao
		{
			get { return duracao; }
			set { duracao = value; }
		}


		public string Assunto
		{
			get { return assunto; }
			set { assunto = value; }
		}

        public DVD(int identificacao, string titulo, SituacaoItem situacao, string assunto, int duracao): base(identificacao, titulo, situacao)
        {
            this.assunto = assunto;
            this.duracao = duracao;
        }
		public DVD() { }

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
            return assunto + ";" + duracao + ";" + demais;
        }
    }
}
