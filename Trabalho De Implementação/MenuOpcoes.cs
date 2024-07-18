using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public class MenuOpcoes
    {
        private CadEmprestimos cadEmprestimos;
        private CadUsuarios cadUsuarios;
        private EntradaDados entradaDados;
        private Acervo acervo;
        private Emprestimo emprestimo;
        private PersistenciaDados persistenciaDados;

        public MenuOpcoes()
        {
            entradaDados = new EntradaDados();
            cadEmprestimos = new CadEmprestimos();
            cadUsuarios = new CadUsuarios();
            acervo = new Acervo();
            emprestimo = new Emprestimo();
            persistenciaDados = new PersistenciaDados();
            this.Menu();
        }

        private void OpcoesMenu()
        {

            Console.WriteLine("1- Cadastra usuário");
            Console.WriteLine("2- Cadastra item na biblioteca");
            Console.WriteLine("3- Realizar emprestimo");
            Console.WriteLine("4- Devolver emprestimo ");
            Console.WriteLine("5- Listar usuários");
            Console.WriteLine("6- Listar livros");
            Console.WriteLine("7- Listar periódicos");
            Console.WriteLine("8- Listar DVD's");
            Console.WriteLine("9- Listar emprestimos");
            Console.WriteLine("10- Excluir usuário");
            Console.WriteLine("11- Excluir item");
            Console.WriteLine("12- Salva os Dados");
            Console.WriteLine("0- Sair");


        }
        private void Menu()
        {
            DVD dvd;
            Periodico periodico;
            Livro livro;
            Usuario usuario;
            int opc = 0;
            if (persistenciaDados.ExisteArquivo("biblioteca.txt") == true)
            {
                acervo = new Acervo();
                persistenciaDados.LeituraDados("biblioteca.txt", acervo);
            }
            if (persistenciaDados.ExisteArquivo("usuarios.txt") == true)
            {
                cadUsuarios = new CadUsuarios();
                persistenciaDados.LeituraDados("usuarios.txt", cadUsuarios);
            }
            this.OpcoesMenu();
            opc = entradaDados.LeInteiro("Informe a sua opção:", 0, 12);
            while (opc != 0)
            {
                switch (opc)
                {
                    case 0:
                        return;

                    case 1:
                        usuario = this.LeDadosUsuario();
                        cadUsuarios.Adicionar(usuario);
                        break;
                    case 2:
                        this.OpcoesItens();
                        int opcd = entradaDados.LeInteiro("Informe a sua opção:", 0, 3);
                        while (opcd != 0)
                        {
                            switch (opcd)
                            {
                                case 1:
                                    livro = this.LeDadosLivro();
                                    acervo.Adicionar(livro);

                                    break;
                                case 2:
                                    periodico = this.LeDadosPeriodico();
                                    acervo.Adicionar(periodico);
                                    break;
                                case 3:
                                    dvd = this.LeDadosDVD();
                                    acervo.Adicionar(dvd);
                                    break;
                            }
                            this.OpcoesItens();
                            opcd = entradaDados.LeInteiro("Informe a sua opção:", 0, 3);
                        }
                        break;
                    case 3:
                        emprestimo = this.LeDadosEmprestimo();
                        if (emprestimo != null)
                        {
                            cadEmprestimos.Adicionar(emprestimo);
                        }
                        break;
                    case 4:
                        emprestimo = this.BuscarEmprestimo();
                        if (emprestimo != null)
                        {
                            emprestimo.Retornar();
                        }

                        break;
                    case 5:
                        cadUsuarios.listar();
                        break;
                    case 6:
                        acervo.ListarLivros();
                        break;
                    case 7:
                        acervo.ListarPeriodicos();
                        break;
                    case 8:
                        acervo.ListarDvd();
                        break;
                    case 9:
                        cadEmprestimos.Listar();
                        break;
                    case 10:
                        this.RemoverUsuario();

                        break;
                    case 11:
                        this.ExcluirItem();
                        break;
                    case 12:
                        if (acervo.Tamanho() != 0)
                        {

                            persistenciaDados.EscritaDados(acervo, "biblioteca.txt");
                        }
                        if (cadUsuarios.Tamanho() != 0)
                        {
                            persistenciaDados.EscritaDados(cadUsuarios, "usuarios.txt");
                        }
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                OpcoesMenu();
                opc = entradaDados.LeInteiro("Informe a sua opção:", 0, 12);
            }
        }

        private void ExcluirItem()
        {
            ItemBiblioteca item;
            int identificacao;
            identificacao = entradaDados.LeInteiro("busque a identificação do item: ");
            item = acervo.Confere(identificacao);
            if (item != null)
            {
                if (item.Situacao == SituacaoItem.Disponivel)
                {
                    acervo.Remover(identificacao);
                }
            }
        }

        private void RemoverUsuario()
        {

            string matricula;


            matricula = entradaDados.LeString("busque a matricula do usuário: ");
            cadUsuarios.Remover(matricula);


        }

        private Emprestimo BuscarEmprestimo()
        {
            Emprestimo emprestimo;
            int x = 1;
            int identificacao;
            do
            {
                identificacao = entradaDados.LeInteiro("busque a identificação do emprestimo: ");
                emprestimo = cadEmprestimos.Confere(identificacao);
                if (emprestimo == null)
                {
                    x = entradaDados.LeInteiro("emprestimo não encontrado, digite 0 para sair ou outro número para tentar novamente.");
                    if (x == 0)
                    {
                        return null;
                    }
                }

            } while (emprestimo == null);
            return emprestimo;




        }



        private Emprestimo LeDadosEmprestimo()
        {
            Usuario usuario;
            ItemBiblioteca item;
            Emprestimo emprestimo;
            int x = 1;
            int identificacao = entradaDados.LeInteiro("digite uma identificação para o emprestimo: ");
            do
            {
                string aux = entradaDados.LeString("digite sua matricula: ");
                usuario = cadUsuarios.Confere(aux);
                if (usuario == null)
                {


                    x = entradaDados.LeInteiro("usuario não cadastrato, digite 0 para sair ou outro número para tentar novamente.");
                    if (x == 0)
                    {
                        return null;
                    }
                }
            } while (usuario == null);
            do
            {
                int auxItem = entradaDados.LeInteiro("digite a identificação do item: ");
                item = acervo.Confere(auxItem);
                if (item == null)
                {
                    Console.WriteLine("Item não encontrado, tente novamente");
                }
                if (item.Situacao != 0)
                {
                    item = null;
                    x = entradaDados.LeInteiro("usuario não cadastrato, digite 0 para sair ou outro número para tentar novamente.");
                    if (x == 0)
                    {
                        return null;
                    }
                }
            } while (item == null);

            DateTime dataEmprestimo = DateTime.Now;
            DateTime dataDevolucao;
            if (item is DVD)
            {
                dataDevolucao = DateTime.Now.AddDays(2);
            }
            else if (item is Periodico)
            {
                dataDevolucao = DateTime.Now.AddDays(4);
            }
            else
            {
                dataDevolucao = DateTime.Now.AddDays(7);
            }
            item.Situacao = SituacaoItem.Emprestado;
            emprestimo = new Emprestimo(identificacao, usuario, item, dataEmprestimo, dataDevolucao);
            return emprestimo;
        }

        private DVD LeDadosDVD()
        {
            DVD dvd;
            int identificacao = entradaDados.LeInteiro("insira a identificação: ");
            string titulo = entradaDados.LeString("insira o titulo");
            SituacaoItem situacao = 0;
            string assunto = entradaDados.LeString("insira o assunto: ");
            int duracao = entradaDados.LeInteiro("insira a duração: ");
            dvd = new DVD(identificacao, titulo, situacao, assunto, duracao);
            return dvd;
        }

        private Periodico LeDadosPeriodico()
        {
            Periodico periodico;
            int identificacao = entradaDados.LeInteiro("insira a identificação: ");
            string titulo = entradaDados.LeString("insira o titulo");
            SituacaoItem situacao = 0;
            string periodicidade = entradaDados.LeString("insira a periodicidade: ");
            int numero = entradaDados.LeInteiro("insira o numero: ");
            int ano = entradaDados.LeInteiro("insira o ano");
            periodico = new Periodico(identificacao, titulo, situacao, periodicidade, numero, ano);
            return periodico;
        }

        private Livro LeDadosLivro()
        {
            Livro livro;
            int identificacao = entradaDados.LeInteiro("insira a identificação: ");
            string titulo = entradaDados.LeString("insira o titulo");
            SituacaoItem situacao = 0;
            string autor = entradaDados.LeString("Insira o autor");
            string editora = entradaDados.LeString("insira a editora");
            int paginas = entradaDados.LeInteiro("insira o numero de paginas");
            livro = new Livro(identificacao, titulo, situacao, autor, editora, paginas);
            return livro;
        }

        private void OpcoesItens()
        {
            Console.WriteLine("1- Cadastra livro");
            Console.WriteLine("2- Cadastra periódicos");
            Console.WriteLine("3- Cadastra DVD");
            Console.WriteLine("0- sair");
        }

        private Usuario LeDadosUsuario()
        {
            Usuario usuario;
            string nome = entradaDados.LeString("informe seu nome:");
            Endereco endereco = this.LeDadosEndereco();
            string matricula = entradaDados.LeString("informe sua matricula");
            string curso = entradaDados.LeString("informe seu curso");
            usuario = new Usuario(nome, endereco, matricula, curso);
            return usuario;
        }

        private Endereco LeDadosEndereco()
        {
            Endereco endereco;
            string rua = entradaDados.LeString("informe sua rua: ");
            int numero = entradaDados.LeInteiro("informe seu numero: ");
            string complemento = entradaDados.LeString("informe seu complemento: ");
            string bairro = entradaDados.LeString("informe seu bairro: ");
            string cidade = entradaDados.LeString("informe sua cidade: ");
            string uf = entradaDados.LeString("informe seu uf");
            string cep = entradaDados.LeString("informe seu cep");
            endereco = new Endereco(rua, numero, complemento, bairro, cidade, uf, cep);
            return endereco;
        }
    }
}