using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class UsuarioDAO
    {
        public void AdicionarUsuario(Usuario usuario)
        {
            using (var context = new SalaoContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public IList<Usuario> ListarUsuarios()
        {
            using (var context = new SalaoContext())
            {
                return context.Usuarios.ToList();
            }
        }

        public Usuario BuscarUsuarioId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Usuarios.Find(id);
            }
        }

        public Usuario BuscarUsuario(string login, string senha)
        {
            using (var context = new SalaoContext())
            {
                return context.Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}