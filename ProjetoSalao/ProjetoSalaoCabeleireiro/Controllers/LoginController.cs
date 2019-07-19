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
            ClienteDAO daoCliente = new ClienteDAO();
            Cliente cliente = daoCliente.BuscarUsuario(login, senha);

            if (cliente != null)
            {
                Session["ClienteLogado"] = cliente;
                return RedirectToAction("IndexHomeCliente", "Home");
            }

            FuncionarioDAO daoFuncionario = new FuncionarioDAO();
            Funcionario funcionario = daoFuncionario.BuscarUsuario(login, senha);

            if (funcionario != null)
            {
                Session["FuncionarioLogado"] = funcionario;
                return RedirectToAction("IndexHomeFuncionario", "Home");
            }
            else
            {
                return RedirectToAction("IndexLogin");
            }
        }

        public ActionResult FazerLogout()
        {
            Session.Clear();
            return RedirectToAction("IndexLogin");
        }
    }
}