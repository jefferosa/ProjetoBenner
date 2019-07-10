using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class EnderecoDAO
    {
        public void AdicionarEndereco(Endereco endereco)
        {
            using (var context = new SalaoContext())
            {
                context.Enderecos.Add(endereco);
                context.SaveChanges();
            }
        }

        public IList<Endereco> ListarEnderecos()
        {
            using (var context = new SalaoContext())
            {
                return context.Enderecos.ToList();
            }
        }
    }
}