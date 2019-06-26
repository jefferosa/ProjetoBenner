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
            ProdutoDAO dao = new ProdutoDAO();
            dao.AdicionarProduto(produto);
            return RedirectToAction("Index");
        }

        public ActionResult DecrementarQtd(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscarProdutoId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return Json(produto);
        }
    }
}