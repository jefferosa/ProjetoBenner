using ProjetoBenner.DAO;
using ProjetoBenner.Filtros;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    [AutorizacaoFuncionario]
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult IndexProduto()
        {
            ProdutoDAO daoProduto = new ProdutoDAO();
            var produtos = daoProduto.ListarProdutos();
            ViewBag.Produto = produtos;
            return View("IndexProduto");
        }

        [HttpPost]
        public ActionResult AdicionarProduto(Produto produto)
        {
            if (produto.Nome == null || produto.Preco == 0 || produto.Quantidade == 0 || produto.Descricao == null)
            {
                ModelState.AddModelError("produto.CadastroEmBranco", "Não pode cadastrar um produto em branco");
            }
            if (ModelState.IsValid)
            {
                ProdutoDAO daoProduto = new ProdutoDAO();
                daoProduto.AdicionarProduto(produto);
                return RedirectToAction("IndexProduto");
            }
            else
            {
                ViewBag.Produto = produto;
                return View("FormularioProduto");
            }
        }

        public ActionResult DecrementarQtd(int id)
        {
            ProdutoDAO daoProduto = new ProdutoDAO();
            Produto produto = daoProduto.BuscarProdutoId(id);

            daoProduto.DecrementarQtd(produto);
            daoProduto.AtualizarProdutos(produto);
            return Json(produto);
        }

        public ActionResult AcrescentarQtd(int id)
        {
            ProdutoDAO daoProduto = new ProdutoDAO();
            Produto produto = daoProduto.BuscarProdutoId(id);
            daoProduto.AcrescentarQtd(produto);
            daoProduto.AtualizarProdutos(produto);
            return Json(produto);
        }
    }
}