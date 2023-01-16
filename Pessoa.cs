using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Projeto_Petshop
{
    public class Pessoa
    {
        public string nome { get; set; }
        public object nascimento = new DateTime();
        public string numeroCPF { get; set; }
        public Pessoa(string Nome, object Nascimento, string CPF)
        {
            this.nome = Nome;
            this.nascimento= Nascimento;    
            this.numeroCPF = CPF;   
        }
    }
}    
