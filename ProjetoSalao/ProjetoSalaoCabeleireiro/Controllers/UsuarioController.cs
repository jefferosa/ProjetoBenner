using ProjetoBenner.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult IndexUsuario()
        {
            return View();
        }

        public ActionResult FormularioUsuario()
        {
            ViewBag.Usuario = new Usuario();
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarUsuario(Usuario usuario)
        {
            if (usuario.Nome == null || usuario.CPF == null ||usuario.Email == null || usuario.Login == null || usuario.Senha == null)
            {
                ModelState.AddModelError("usuario.CadastroEmBranco", "Não pode cadastrar um usuario em branco");
            }
            if (ModelState.IsValid)
            {
                UsuarioDAO dao = new UsuarioDAO();
                dao.AdicionarUsuario(usuario);
                return RedirectToAction("IndexLogin", "Login");
            }
            else
            {
                ViewBag.Usuario = usuario;
                return View("FormularioUsuario");
            }
        }
    }
}