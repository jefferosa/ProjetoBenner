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

        public IList<Produto> ListarProdutos()
        {

            IList<Produto> itens = new List<Produto>();
            using (var context = new SalaoContext())
            {
                return context.Produtos.ToList();
            }
        }

        public Produto BuscarProdutoId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Produtos
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void AtualizarProdutos(Produto produto)
        {
            using (var context = new SalaoContext())
            {
                context.Produtos.Update(produto);
                context.SaveChanges();
            }
        }

        public void DecrementarQtd(Produto produto)
        {
            if(produto.Quantidade > 0)
            {
                produto.Quantidade--;
            }
            
        }

        public void AcrescentarQtd(Produto produto)
        {
            if(produto.Quantidade >= 0)
            {
                produto.Quantidade++;
            }
            
        }
    }
}