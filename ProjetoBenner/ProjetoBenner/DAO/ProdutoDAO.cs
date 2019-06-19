using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class ProdutoDAO
    {
        public void AdicionaProduto(Produto produto)
        {
            using (var context = new SalaoContext())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public void RemoveProduto(Produto produto)
        {
            using(var context = new SalaoContext())
            {
                context.Produtos.Remove(produto);
                context.SaveChanges();
            }
        }

        public Produto BuscaProdutoId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Produtos.Find(id);
            }
        }

        public IList<Produto> ListaProdutos()
        {
            using (var context = new SalaoContext())
            {
                return context.Produtos.ToList();
            }
        }
    }
}