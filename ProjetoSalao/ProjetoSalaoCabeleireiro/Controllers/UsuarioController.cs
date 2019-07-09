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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulario()
        {
            ViewBag.Usuario = new Usuario();
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarUsuario(Usuario usuario)
        {
            if (usuario.Nome == null || usuario.CPF == 0 || usuario.Email == null || usuario.Login == null || usuario.Senha == null)
            {
                ModelState.AddModelError("usuario.CadastroEmBranco", "Não pode cadastrar um usuario em branco");
            }
            if (ModelState.IsValid)
            {
                UsuarioDAO dao = new UsuarioDAO();
                dao.AdicionarUsuario(usuario);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Usuario = usuario;
                return View("Formulario");
            }
        }
    }
}