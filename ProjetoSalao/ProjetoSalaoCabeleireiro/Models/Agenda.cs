using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public Servico Servico { get; set; }
        public int? ServicoId { get; set; }
    }
}