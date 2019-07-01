using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBenner.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [StringLength(20)]
        public String Nome { get; set; }

        public double Preco { get; set; }

        public String Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}