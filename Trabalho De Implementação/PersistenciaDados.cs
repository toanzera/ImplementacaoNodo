using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace Trabalho_De_Implementação
{
    internal class PersistenciaDados
    {
        internal void EscritaDados(Acervo acervo, string arquivo)
        {
            Livro livro = null;
            Periodico periodico = null;
            DVD dvd = null;
            string linha;
            try
            {
                using (StreamWriter sw = new StreamWriter(arquivo))
                    for (int i = 1; i <= acervo.Tamanho(); i++)
                    {
                        if (acervo.Busca(i) is Livro)
                        {
                            livro = (Livro)acervo.Busca(i);
                            linha = livro.ToString();
                            sw.WriteLine(linha);
                        }
                        else if (acervo.Busca(i) is Periodico)
                        {
                            periodico = (Periodico)acervo.Busca(i);
                            linha = periodico.ToString();
                            sw.WriteLine(linha);
                        }
                        else
                        {
                            dvd = (DVD)acervo.Busca(i);
                            linha = dvd.ToString();
                            sw.WriteLine(linha);
                        }


                    }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro!\n" + ex.Message);
            }
        }


        internal void EscritaDados(CadUsuarios cadUsuarios, string arquivo)
        {
            Usuario item = null;
            string linha;
            try
            {
                using (StreamWriter sw = new StreamWriter(arquivo))
                    for (int i = 1; i <= cadUsuarios.Tamanho(); i++)
                    {
                        item = cadUsuarios.Busca(i);
                        linha = item.ToString();
                        sw.WriteLine(linha);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro!\n" + ex.Message);
            }
        }

        internal bool ExisteArquivo(string arquivo)
        {
            return File.Exists(arquivo);

        }

        internal void LeituraDados(string arquivo, CadUsuarios cadUsuarios)
        {
            string linha = "";
            string matricula = "";
            string curso = "";
            string nome = "";
            Endereco endereco;
            Usuario usuario = null;
            if (ExisteArquivo(arquivo))
            {
                try
                {
                    StreamReader sr = new StreamReader(arquivo);
                    char[] delimitador = { ';' };
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] linhaSplit = linha.Split(delimitador);
                        matricula = linhaSplit[0];
                        curso = linhaSplit[1];
                        nome = linhaSplit[2];
                        endereco = new Endereco();
                        endereco.Rua = linhaSplit[3];
                        endereco.Numero = int.Parse(linhaSplit[4]);
                        endereco.Complemento = linhaSplit[5];
                        endereco.Bairro = linhaSplit[6];
                        endereco.Cidade = linhaSplit[7];
                        endereco.Uf = linhaSplit[8];
                        endereco.Cep = linhaSplit[9];

                        usuario = new Usuario();
                        usuario.Matricula = matricula;
                        usuario.Curso = curso;
                        usuario.Endereco = endereco;
                        usuario.Nome = nome;
                        cadUsuarios.Adicionar(usuario);

                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro!\n" + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Término da Leitura de Dados do Arquivo " + arquivo);
                }
            }

        }


        internal void LeituraDados(string arquivo, Acervo acervo)
        {
            int n = 0;
            string linha = "";
            //livro
            string autor = "";
            string editora = "";
            int paginas = 0;

            //DVD
            string assunto = "";
            int duracao = 0;
            //periodico
            string periodicidade = "";
            int numero = 0;
            int ano = 0;
            // itembiblioteca
            int identificacao = 0;
            string titulo = "";
            SituacaoItem situacao;

            Livro livro = null;
            DVD dvd = null;
            Periodico periodico = null;
            if (ExisteArquivo(arquivo))
            {
                try
                {
                    StreamReader sr = new StreamReader(arquivo);
                    char[] delimitador = { ';' };
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] linhaSplit = linha.Split(delimitador);
                        if ((int.TryParse(linhaSplit[1], out n)) && (int.TryParse(linhaSplit[3], out n)))
                        {
                            periodicidade = linhaSplit[0];
                            numero = int.Parse(linhaSplit[1]);
                            ano = int.Parse(linhaSplit[2]);
                            identificacao = int.Parse(linhaSplit[3]);
                            titulo = linhaSplit[4];
                            if (linhaSplit[5].Equals("Disponivel"))
                            {
                                situacao = SituacaoItem.Disponivel;
                            }
                            else if (linhaSplit[5].Equals("Emprestado"))
                            {
                                situacao = SituacaoItem.Emprestado;
                            }
                            else if (linhaSplit[5].Equals("Bloqueado"))
                            {
                                situacao = SituacaoItem.Bloqueado;
                            }
                            else
                            {
                                situacao = SituacaoItem.Atrasado;
                            }

                            periodico = new Periodico(identificacao, titulo, situacao, periodicidade, numero, ano);
                            acervo.Adicionar(periodico);
                        }
                        else if ((!int.TryParse(linhaSplit[0], out n)) && (int.TryParse(linhaSplit[1], out n)))
                        {
                            assunto = linhaSplit[0];
                            duracao = int.Parse(linhaSplit[1]);
                            identificacao = int.Parse(linhaSplit[2]);
                            titulo = linhaSplit[3];
                            if (linhaSplit[4].Equals("Disponivel"))
                            {
                                situacao = SituacaoItem.Disponivel;
                            }
                            else if (linhaSplit[4].Equals("Emprestado"))
                            {
                                situacao = SituacaoItem.Emprestado;
                            }
                            else if (linhaSplit[4].Equals("Bloqueado"))
                            {
                                situacao = SituacaoItem.Bloqueado;
                            }
                            else
                            {
                                situacao = SituacaoItem.Atrasado;
                            }
                            dvd = new DVD(identificacao, titulo, situacao, assunto, duracao);
                            acervo.Adicionar(dvd);

                        }
                        else
                        {
                            autor = linhaSplit[0];
                            editora = linhaSplit[1];
                            paginas = int.Parse(linhaSplit[2]);
                            identificacao = int.Parse(linhaSplit[3]);
                            titulo = linhaSplit[4];
                            if (linhaSplit[5].Equals("Disponivel"))
                            {
                                situacao = SituacaoItem.Disponivel;
                            }
                            else if (linhaSplit[5].Equals("Emprestado"))
                            {
                                situacao = SituacaoItem.Emprestado;
                            }
                            else if (linhaSplit[5].Equals("Bloqueado"))
                            {
                                situacao = SituacaoItem.Bloqueado;
                            }
                            else
                            {
                                situacao = SituacaoItem.Atrasado;
                            }
                            livro = new Livro(identificacao, titulo, situacao, autor, editora, paginas);
                            acervo.Adicionar(livro);

                        }

                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro!\n" + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Término da Leitura de Dados do Arquivo " + arquivo);
                }
            }
        }
    }
}


