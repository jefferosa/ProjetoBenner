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

        public IList<HorarioAtendimento> ListarHorarioAtendimento()
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

        public int ContaAgendamentos()
        {
            int cont = 0;

            var agendamentos = ListarAgendamentos();
            foreach(var lista in agendamentos)
            {
                if(lista.Estado != "Finalizado")
                {
                    cont++;
                }
            }
            return cont;
        }

        public void AtualizarAgendamento(Agenda agenda)
        {
            using (var context = new SalaoContext())
            {
                context.Agenda.Update(agenda);
                context.SaveChanges();
            }
        }

        public Agenda BuscarAgendamentoId(int? id)
        {
            using (var context = new SalaoContext())
            {
                return context.Agenda.Find(id);
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

        public void AvancaEstado(Agenda agenda)
        {
            using (var context = new SalaoContext())
            {
                context.Entry(agenda).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}