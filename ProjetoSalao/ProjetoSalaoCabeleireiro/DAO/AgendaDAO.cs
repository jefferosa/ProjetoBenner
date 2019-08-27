using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class AgendaDAO
    {
        
        public bool AgendarHorario(Agenda agenda)
        {
            bool valida = false;
            using (var context = new SalaoContext())
            {
                context.Agenda.Add(agenda);
                context.SaveChanges();

                valida = true;
            }
            return valida;
        }

        public IList<HorarioAtendimento> Listar()
        {
            using (var context = new SalaoContext())
            {
                return context.Horarios.ToList();
            }
        }

        public IList<Agenda> ListarAgendamentos()
        {
            using (var context = new SalaoContext())
            {
                return context.Agenda.ToList();
            }
        }

        public void RemoverHorario(Agenda agenda)
        {
            using (var context = new SalaoContext())
            {
                context.Agenda.Remove(agenda);
                context.SaveChanges();
            }
        }
    }
}