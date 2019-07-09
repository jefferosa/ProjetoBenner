using ProjetoBenner.DAO;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutoDAO dao = new ProdutoDAO();
            IList<Produto> produtos = dao.ListarProdutos();
            ViewBag.Produto = produtos;
            return View("Index");
        }

        public ActionResult Formulario()
        {
            ViewBag.Produto = new Produto();
            return View();
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
                ProdutoDAO dao = new ProdutoDAO();
                dao.AdicionarProduto(produto);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Produto = produto;
                return View("Formulario");
            }
        }

        public ActionResult DecrementarQtd(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscarProdutoId(id);
            produto.Quantidade--;
            dao.AtualizarProdutos(produto);
            return Json(produto);
        }
    }
}