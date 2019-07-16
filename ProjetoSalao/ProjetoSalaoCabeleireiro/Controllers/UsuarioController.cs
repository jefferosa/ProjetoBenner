using ProjetoBenner.DAO;
using ProjetoBenner.Models;
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
        public ActionResult IndexCliente()
        {
            return View();
        }

        public ActionResult FormularioCliente()
        {
            ViewBag.Cliente = new Cliente();
            return View();
        }

        public ActionResult FormularioFuncionario()
        {
            ViewBag.Cliente = new Cliente();
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarCliente(Cliente cliente)
        {
            if (cliente.Nome == null || cliente.CPF == null ||cliente.Email == null || cliente.Login == null || cliente.Senha == null)
            {
                ModelState.AddModelError("usuario.CadastroEmBranco", "Não pode cadastrar um usuario em branco");
            }
            if (ModelState.IsValid)
            {
                ClienteDAO dao = new ClienteDAO();
                dao.AdicionarCliente(cliente);
                return RedirectToAction("IndexLogin", "Login");
            }
            else
            {
                ViewBag.Cliente = cliente;
                return View("FormularioCliente");
            }
        }

        public ActionResult AdicionarFuncionario(Funcionario funcionario)
        {
            if (funcionario.Nome == null || funcionario.CPF == null || funcionario.Email == null || funcionario.Login == null || funcionario.Senha == null)
            {
                ModelState.AddModelError("usuario.CadastroEmBranco", "Não pode cadastrar um usuario em branco");
            }
            if (ModelState.IsValid)
            {
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.AdicionarFuncionario(funcionario);
                return RedirectToAction("IndexLogin", "Login");
            }
            else
            {
                ViewBag.Funcionario = funcionario;
                return View("FormularioFuncionario");
            }
        }
    }
}