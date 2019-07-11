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
        public ActionResult IndexLogin()
        {
            return View();
        }

        public ActionResult AutenticaLogin(string login, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.BuscarUsuario(login, senha);
            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("IndexHome", "Home");
            }
            else
            {
                return RedirectToAction("IndexLogin");
            }
        }
    }
}