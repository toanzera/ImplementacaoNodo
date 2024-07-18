﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class Endereco
    {
        private string rua;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string uf;
        private string cep;

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }


        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }


        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }


        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }


        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public Endereco(string rua, int numero, string complemento, string bairro, string cidade, string uf, string cep)
        {
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cidade = cidade;
            this.uf = uf;
            this.cep = cep;
        }
        public Endereco() { }

        public override string ToString()
        {
            return rua + ";" + numero + ";" + complemento + ";" + bairro + ";" + cidade + ";" + uf + ";" + cep;
        }
    }
}