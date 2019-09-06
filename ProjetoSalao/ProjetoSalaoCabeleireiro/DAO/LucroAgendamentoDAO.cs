using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class LucroAgendamentoDAO
    {
        public void AdicionarEntrada(LucroAgendamento lucroAgendamento)
        {
            using (var context = new SalaoContext())
            {
                context.Lucros.Add(lucroAgendamento);
                context.SaveChanges();
            }
        }

        public IList<LucroAgendamento> ListarEntradas()
        {
            using (var context = new SalaoContext())
            {
                return context.Lucros.ToList();
            }
        }

        public double LucroMensal()
        {
            double lucroMensal = 0.0;
            var Lista = ListarEntradas();
            DateTime Data = DateTime.Today;
            
            foreach (var lucro in Lista)
            {
                if (lucro.DataEntrada.Month == Data.Month)
                {
                    lucroMensal += lucro.ValorEntrada;
                }
            }

            return lucroMensal;
        }
       
    }
}