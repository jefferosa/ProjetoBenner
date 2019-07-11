using ProjetoBenner.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Endereco
        public ActionResult IndexEndereco()
        {
            return View();
        }

        public ActionResult FormularioEndereco()
        {
            ViewBag.Endereco = new Endereco();
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarEndereco(Endereco endereco)
        {
            if (endereco.Rua == null || endereco.Numero == 0 || endereco.Bairro == null || endereco.Cidade == null)
            {
                ModelState.AddModelError("produto.CadastroEmBranco", "Não pode cadastrar um produto em branco");
            }
            if (ModelState.IsValid)
            {
                EnderecoDAO dao = new EnderecoDAO();
                dao.AdicionarEndereco(endereco);
                return RedirectToAction("IndexHome", "Home");
            }
            else
            {
                ViewBag.Endereco = endereco;
                return View("FormularioEndereco");
            }
        }
    }
}