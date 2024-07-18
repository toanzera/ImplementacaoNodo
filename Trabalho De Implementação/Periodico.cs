using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Periodico : ItemBiblioteca, IEmprestavel
    {


        private string periodicidade;
        private int numero;
        private int ano;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }


        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }
        public string Periodicidade
        {
            get { return periodicidade; }
            set { periodicidade = value; }
        }

        public Periodico(int identificacao, string titulo, SituacaoItem situacao, string periodicidade, int numero, int ano): base (identificacao, titulo, situacao)
        {
            this.periodicidade = periodicidade;
            this.numero = numero;
            this.ano = ano;
        }

        public Periodico() : base() { }

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
            return periodicidade + ";" + numero + ";" + ano + ";" + demais;
        }
    }
}
