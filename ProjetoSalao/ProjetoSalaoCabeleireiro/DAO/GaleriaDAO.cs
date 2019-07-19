using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class GaleriaDAO
    {
        public void AdicionarImagem(Galeria galeria)
        {
            using (var context = new SalaoContext())
            {
                context.Galeria.Add(galeria);
                context.SaveChanges();
            }
        }

        public IList<Galeria> ListarImagens()
        {
            
            using (var context = new SalaoContext())
            {
                return context.Galeria.ToList();
            }
        }

        public void AtualizarImagens(Galeria galeria)
        {
            using (var context = new SalaoContext())
            {
                context.Galeria.Update(galeria);
                context.SaveChanges();
            }
        }
    }
}