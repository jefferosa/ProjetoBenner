using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public DateTime Data { get; set; }
    }
}