using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class ClienteDAO
    {
        public void AdicionarCliente(Cliente cliente)
        {
            using (var context = new SalaoContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        public IList<Cliente> ListarClientes()
        {
            IList<Cliente> itens = new List<Cliente>();
            using (var context = new SalaoContext())
            {
                return context.Clientes.ToList();
            }
        }

        public Cliente BuscarClienteId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Clientes.Find(id);
            }
        }

        public Cliente BuscarUsuario(string login, string senha)
        {
            using (var context = new SalaoContext())
            {
                return context.Clientes.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}