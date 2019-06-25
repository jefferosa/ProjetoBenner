using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class CadastroDAO
    {
        public void AdicionarCadastro(Cadastro cadastro)
        {
            using (var context = new SalaoContext())
            {
                context.Cadastros.Add(cadastro);
                context.SaveChanges();
            }
        }

        public IList<Cadastro> ListarCadastros()
        {
            using (var context = new SalaoContext())
            {
                return context.Cadastros.ToList();
            }
        }

        public Cadastro BuscarCadastroId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Cadastros.Find(id);
            }
        }

        public Cadastro BuscarCadastro(string login, string senha)
        {
            using (var context = new SalaoContext())
            {
                return context.Cadastros.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}