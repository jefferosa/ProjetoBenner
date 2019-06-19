using ProjetoBenner.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AutenticaLogin(string login, string senha)
        {
            CadastroDAO dao = new CadastroDAO();
            Cadastro cadastro = dao.BuscaCadastro(login, senha);
            if (cadastro != null)
            {
                Session["usuarioLogado"] = cadastro;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}