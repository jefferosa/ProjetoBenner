using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBenner
{
    public class Usuario
    {
        public int Id { get; set; }
        [MaxLength(11)]
        public string CPF { get; set; }
        public string Nome { get; set; }
        [MaxLength(12)]
        public string Telefone { get; set; }
        [MinLength(6)]
        public string Senha { get; set; }
        [MinLength(4)]
        public string Login { get; set; }
        public string Email { get; set; }
        public int CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }

        public Agenda Agenda { get; set; }
    }
}