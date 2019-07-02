using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.Models
{
    public class ControleFinanceiro
    {
        public int Id { get; set; }
        public Entrada Entradas { get; set; }
        public Saida Saidas { get; set; }
    }
}