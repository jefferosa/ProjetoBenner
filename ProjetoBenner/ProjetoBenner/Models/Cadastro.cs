using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner
{
    public class Cadastro
    {
        public int Id { get; set; }
        public int CPF { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public Endereco Enderecos { get; set; }
    }
}