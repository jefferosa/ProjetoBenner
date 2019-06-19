using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class CadastroDAO
    {
        public void AdicionaCadastro(Cadastro cadastro)
        {
            using (var context = new SalaoContext())
            {
                context.Cadastros.Add(cadastro);
                context.SaveChanges();
            }
        }

        public IList<Cadastro> ListaCadastros()
        {
            using (var context = new SalaoContext())
            {
                return context.Cadastros.ToList();
            }
        }

        public Cadastro BuscaCadastroId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Cadastros.Find(id);
            }
        }

        public Cadastro BuscaCadastro(string login, string senha)
        {
            using (var context = new SalaoContext())
            {
                return context.Cadastros.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}