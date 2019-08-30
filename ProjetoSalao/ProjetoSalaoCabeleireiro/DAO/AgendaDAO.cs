using Microsoft.EntityFrameworkCore;
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

        public int BuscarAgendamento(DateTime horaSelecionada, DateTime data)
        {
            using (var context = new SalaoContext())
            {
                int cont = 0;
                cont = context.Agenda.Count(u => u.Horario == horaSelecionada && u.Data == data);

                return cont;
            }
        }

        public IList<Agenda> ListarAgendamentos()
        {
            using (var context = new SalaoContext())
            {
                return context.Agenda.Include(p => p.Servico).Include(c => c.Cliente).ToList();
            }
        }

        public Cliente BuscarClienteId(int? id)
        {
            using (var context = new SalaoContext())
            {
                return context.Clientes.Find(id);
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