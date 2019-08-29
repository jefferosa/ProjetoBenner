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

        [Display(Name = "CPF: ")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [MaxLength(12)]
        public string Telefone { get; set; }
        [MinLength(6)]
        public string Senha { get; set; }
        [MinLength(4)]
        public string Login { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }

        public Agenda Agenda { get; set; }
    }
}