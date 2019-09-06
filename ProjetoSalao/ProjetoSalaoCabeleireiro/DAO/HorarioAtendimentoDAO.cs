using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class HorarioAtendimentoDAO
    {
        bool valida = false;
        public bool AdicionarHorarioAtendimento(HorarioAtendimento horarioAtendimento)
        {
            using (var context = new SalaoContext())
            {
                context.Horarios.Add(horarioAtendimento);
                context.SaveChanges();
                valida = true;
            }
            return valida;
        }

        public IList<HorarioAtendimento> ListarHorarioAtendimento()
        {
            IList<HorarioAtendimento> horarioAtendimentos = new List<HorarioAtendimento>();
            using (var context = new SalaoContext())
            {
                return context.Horarios.ToList();
            }
        }

        public HorarioAtendimento ListarHorarios()
        {
            using (var context = new SalaoContext())
            {
                return context.Horarios.First();
            }
        }

        public HorarioAtendimento BuscarHorariosId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Horarios
                    .Where(u => u.Id == id)
                    .FirstOrDefault();
            }
        }

        public void AtualizarHorarioAtendimento(HorarioAtendimento horarioAtendimento)
        {
            using (var context = new SalaoContext())
            {
                context.Horarios.Update(horarioAtendimento);
                context.SaveChanges();
            }
        }
    }
}