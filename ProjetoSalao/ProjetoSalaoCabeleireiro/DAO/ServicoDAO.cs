using ProjetoBenner.Models;
using System.Collections.Generic;
using System.Linq;
namespace ProjetoBenner.DAO
{
    public class ServicoDAO
    {
        public void AdicionarServico(Servico servico)
        {
            using (var context = new SalaoContext())
            {
                context.Servicos.Add(servico);
                context.SaveChanges();
            }
        }

        public IList<Servico> ListaServicos()
        {
            IList<Servico> itens = new List<Servico>();
            using (var context = new SalaoContext())
            {
                return context.Servicos.ToList();
            }
        }

        public Servico BuscarServicoId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Servicos.Find(id);
            }
        }

        public void AtualizarServico(Servico servico)
        {
            using (var context = new SalaoContext())
            {

            }
        }
    }
}