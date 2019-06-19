using ProjetoBenner.DAO;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class ServicoController : Controller
    {
        // GET: Servico
        public ActionResult Index()
        {
            ServicoDAO dao = new ServicoDAO();
            IList<Servico> servicos = dao.ListaServicos();
            ViewBag.Sevicos = servicos;
            return View();
        }

        public ActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaServico(Servico servico)
        {
            ServicoDAO dao = new ServicoDAO();
            dao.AdicionaServico(servico);
            return View();
        }
    }
}