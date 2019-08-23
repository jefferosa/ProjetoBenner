using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace ProjetoBenner.Models
{
    public class HorarioAtendimento
    {
        public int Id { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime HorarioFechamento { get; set; }
    }
}