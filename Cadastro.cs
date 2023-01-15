using System;
using System.Collections.Generic;

namespace Projeto_Petshop
{
    public class Cadastro
    {
        ValidacoesDeDados isValid = new ValidacoesDeDados();
        string Nome;
        static DateTime Nascimento = new DateTime();


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
        public void gravaPessoa()
        {
            pessoas.Add(new Pessoa(registraNome(), RegistraNascimento(), registraCPF()));
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
    }
}

