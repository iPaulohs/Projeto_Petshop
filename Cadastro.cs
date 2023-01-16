using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Projeto_Petshop
{
    public class Cadastro
    {
        ValidacoesDeDados isValid = new ValidacoesDeDados();
        string Nome;
        Pessoa pessoa;
        static DateTime Nascimento = new DateTime();
        List<Pessoa> persons = new List<Pessoa>();
        StreamWriter db_Pessoas = new StreamWriter("C:\\Users\\paulo\\source\\repos\\Projeto_Petshop\\DB_PessoasEntrada.txt", true, Encoding.ASCII);


        public string registraNome()
        {
            Console.WriteLine("Digite o nome do cliente: ");
            Nome = Console.ReadLine().ToUpper();

            if(isValid.ValidaNome(Nome) == false)
            {
                Console.WriteLine("Nome inválido! Digite entre 3 e 80 caracteres.");
                registraNome();
                return "";
            }
            else
            {
                return Nome;
            }
            
        }
        public object RegistraNascimento()
        {
            Console.WriteLine("Digite a data de nascimento: ");
            Nascimento = DateTime.Parse(Console.ReadLine());
            
            
            if(isValid.ValidaIdade(Nascimento) == false)
            { 
                Console.WriteLine("Idade inválida. A idade precisa ser entre 16 e 120 anos.");
                RegistraNascimento();
                return false;
            }
            else
            {
                Nascimento.ToString("d");
                return Nascimento;
            }

        }
        public string registraCPF()
        {
            Console.WriteLine("Digite o seu CPF: ");
            string CPF = Console.ReadLine();
            if (isValid.validaCPF(CPF) == false)
            {
                Console.WriteLine("CPF invalido.");
                registraCPF();
                return "";
            }
            else
            {
                return CPF;
            }
        }

        List<Pessoa> pessoas = new List<Pessoa>();
        public void GravaPessoa()
        {
            pessoa = new Pessoa(registraNome(), RegistraNascimento(), registraCPF());
            persons.Add(pessoa);            

            try
            {
                db_Pessoas.WriteLine(pessoa.nome + ", " + pessoa.numeroCPF + ", " + pessoa.nascimento);
                db_Pessoas.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Final da gravação.");
            }

            var linhas = File.ReadAllLines("C:\\Users\\paulo\\source\\repos\\Projeto_Petshop\\DB_PessoasEntrada.txt"); 
            linhas = linhas.Select(l => $"-{l}").ToArray();        
            File.WriteAllLines("C:\\Users\\paulo\\source\\repos\\Projeto_Petshop\\DB_PessoasSaida.txt", linhas);         


        }
        public void FindPerson()
        {
            Console.WriteLine("Digite o CPF a ser buscado: ");
            string cpfFind = Console.ReadLine();

            foreach(Pessoa p in pessoas)
            {
                if(p.numeroCPF == cpfFind)
                {
                    Console.WriteLine(p.nome + " " + p.numeroCPF + " " + p.nascimento);
                }
            }
        }
        public void ListaPessoas()
        {
            string pessoa = File.ReadAllText("C:\\Users\\paulo\\source\\repos\\Projeto_Petshop\\DB_PessoasSaida.txt");
            Console.WriteLine(pessoa);
        }
    }
}

