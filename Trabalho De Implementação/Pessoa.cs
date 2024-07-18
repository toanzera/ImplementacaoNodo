using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Pessoa
    {
		private string nome;
		private Endereco endereco;

		public Endereco Endereco
		{
			get { return endereco; }
			set { endereco = value; }
		}

		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

        public Pessoa(string nome, Endereco endereco)
        {
            this.nome = nome;
            this.endereco = endereco;
        }
        public Pessoa() { }
        public override string ToString()
        {
            return nome + ";" + endereco;
        }

    }
}
