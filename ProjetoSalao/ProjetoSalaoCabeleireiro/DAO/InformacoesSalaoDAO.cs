using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class InformacoesSalaoDAO
    {
        public void CadastrarInformacoes(InformacoesSalao dados)
        {
            using (var context = new SalaoContext())
            {
                context.Dados.Add(dados);
                context.SaveChanges();
                
            }
        }

        public InformacoesSalao Listar()
        {
            using (var context = new SalaoContext())
            {
                return context.Dados.First();
            }
        }

        public IList<InformacoesSalao> ListarDados()
        {
            using (var context = new SalaoContext())
            {
                return context.Dados.ToList();
            }
        }

        public InformacoesSalao BuscarInformacoesId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Dados.Find(id);
            }
        }

        public void AtualizarInformacoes(InformacoesSalao dados)
        {
            using (var context = new SalaoContext())
            {
                context.Dados.Update(dados);
                context.SaveChanges();
            }
        }
    }
}