using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.Models
{
    public class InformacoesSalao
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}