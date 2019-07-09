using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class ControleFinanceiroDAO
    {
        public void AdicionarEntrada(Entrada entrada)
        {
            using (var context = new SalaoContext())
            {
                context.Entradas.Add(entrada);
                context.SaveChanges();
            }
        }

        public void AdicionarSaida(Saida saida)
        {
            using (var context = new SalaoContext())
            {
                context.Saidas.Add(saida);
                context.SaveChanges();
            }
        }

        public IList<Entrada> ListarEntradas()
        {

            IList<Entrada> itens = new List<Entrada>();
            using (var context = new SalaoContext())
            {
                return context.Entradas.ToList();
            }
        }

        public IList<Saida> ListarSaidas()
        {

            IList<Saida> itens = new List<Saida>();
            using (var context = new SalaoContext())
            {
                return context.Saidas.ToList();
            }
        }
    }
}