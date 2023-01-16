using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Petshop
{
    internal class Fluxo
    {
        Cadastro cadastro = new Cadastro();
        int opcaoNumero;
        public int opcao()
        {
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Cadastrar pessoa");
            Console.WriteLine("2 - Procurar por CPF");
            Console.WriteLine("3 - Listas pessoas");
            //Console.WriteLine("4 - Aniversariantes do mês");
            opcaoNumero = int.Parse(Console.ReadLine());
            if(opcaoNumero < 1 || opcaoNumero > 4) 
            {
                Console.WriteLine("Digite uma opção válida.");
                opcao();
                return 0;
            }
            else
            {
                fluxo();
                return opcaoNumero;
            }
        }
        public void fluxo()
        {
            switch (opcaoNumero)
            {
                case 1:
                    cadastro.GravaPessoa();
                    opcao();
                    break;
                case 2:
                    cadastro.FindPerson();
                    opcao();
                    break;
                case 3:
                    cadastro.ListaPessoas();
                    opcao();
                    break;
                case 4:
                    //Procurar por CPF
                    break;
            }
        }
    }
}
