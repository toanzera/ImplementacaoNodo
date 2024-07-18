using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
   public enum SituacaoItem
    {
        Disponivel,
        Emprestado,
        Bloqueado,
        Atrasado
    }
    public abstract class ItemBiblioteca
    {
		private int identificacao;
		private string titulo;
		private SituacaoItem situacao;

		public SituacaoItem Situacao
		{
			get { return situacao; }
			set { situacao = value; }
		}
        public string Titulo
		{
			get { return titulo; }
			set { titulo = value; }
		}


		public int Identificacao
		{
			get { return identificacao; }
			set { identificacao = value; }
		}
        protected ItemBiblioteca(int identificacao, string titulo, SituacaoItem situacao)
        {
            this.identificacao = identificacao;
			this.titulo = titulo;
            this.situacao = situacao;
        }
		protected ItemBiblioteca() { }

        public virtual string Tostring()
        {
			return identificacao + ";" + titulo + ";" + situacao; 
        }
    }
}
