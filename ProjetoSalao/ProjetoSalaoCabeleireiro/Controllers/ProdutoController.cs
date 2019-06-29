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
            var produtos = dao.ListarProdutos();
            return View(produtos);
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
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Produto = produto;
                return View("Formulario");
            }
        }

        [Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscarProdutoId(id);
            ViewBag.Produto = produto;
            return View();
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