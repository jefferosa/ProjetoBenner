using ProjetoBenner.DAO;
using ProjetoBenner.Filtros;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult IndexHomeCliente()
        {
            return View();
        }

        [AutorizacaoFuncionario]
        public ActionResult IndexHomeFuncionario()
        {
            return View();
        }
    }
}