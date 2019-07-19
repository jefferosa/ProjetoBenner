using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using ProjetoBenner.Models;

namespace ProjetoBenner
{
    public class Endereco
    {
        public int Id { get; set; }
        public int CEP { get; set; }
        public int Numero { get; internal set; }
        public string Rua { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
    }
}