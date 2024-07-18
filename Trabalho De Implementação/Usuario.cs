using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Usuario : Pessoa

    {
        private string matricula;
        private string curso;
        private bool emprestimoAtual = true;

        public bool EmprestimoAtual

        {
            get { return emprestimoAtual; }
            set { emprestimoAtual = value; }
        }

        public string Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }

        }
        

        public Usuario() : base()
        {

        }
        public Usuario(string matricula)
        {
            this.matricula = matricula;
        }
        public Usuario(string nome, Endereco endereco, string matricula, string curso) : base(nome, endereco)
        {
            this.matricula = matricula;
            this.curso = curso;
        }

        public bool Emprestimo()
        {
            if (emprestimoAtual == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return matricula + ";" + curso + ";" + base.ToString();
        }
    }
}
