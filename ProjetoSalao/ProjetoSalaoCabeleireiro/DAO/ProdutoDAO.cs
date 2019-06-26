using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class ProdutoDAO
    {
        public void AdicionarProduto(Produto produto)
        {
            using (var context = new SalaoContext())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public Produto BuscarProdutoId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Produtos.Find(id);
            }
        }

        public IList<Produto> ListarProdutos()
        {
            using (var context = new SalaoContext())
            {
                return context.Produtos.ToList();
            }
        }
    }
}