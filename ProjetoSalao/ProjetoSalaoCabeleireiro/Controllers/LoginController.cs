using ProjetoBenner.DAO;
using ProjetoBenner.Models;
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
            FuncionarioDAO daoFuncionario = new FuncionarioDAO();
            Funcionario funcionario = daoFuncionario.BuscarUsuario(login, senha);

            ClienteDAO daoCliente = new ClienteDAO();
            Cliente cliente = daoCliente.BuscarUsuario(login, senha);

            if (cliente != null)
            {
                Session["clienteLogado"] = cliente;
                return RedirectToAction("IndexHomeCliente", "Home");
            }
            else if (funcionario != null)
            {
                Session["funcionarioLogado"] = funcionario;
                return RedirectToAction("IndexHomeFuncionario", "Home");
            }
            else
            {
                return RedirectToAction("IndexLogin");
            }
        }
    }
}