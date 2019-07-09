using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class AgendaDAO
    {
        public void AgendarHorario(Agenda agenda)
        {
            using(var context = new SalaoContext())
            {
                context.Agenda.Add(agenda);
                context.SaveChanges();
            }
        }

        public void RemoverHorario(Agenda agenda)
        {
            using(var context = new SalaoContext())
            {
                context.Agenda.Remove(agenda);
                context.SaveChanges();
            }
        }
    }
}