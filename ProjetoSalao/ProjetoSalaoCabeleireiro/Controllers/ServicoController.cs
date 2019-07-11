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
        public ActionResult IndexServico()
        {
            ServicoDAO dao = new ServicoDAO();
            IList<Servico> servicos = dao.ListaServicos();
            ViewBag.Servico = servicos;
            return View("IndexServico");
        }

        public ActionResult FormularioServico()
        {
            ViewBag.Servico = new Servico();
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarServico(Servico servico)
        {
            if (servico.Tipo == null || servico.Tempo == 0 || servico.Valor == 0)
            {
                ModelState.AddModelError("servico.CadastroComValorNulo", "Não pode cadastrar um serviço nulo");
            }
            if (ModelState.IsValid)
            {
                ServicoDAO dao = new ServicoDAO();
                dao.AdicionarServico(servico);
                return RedirectToAction("IndexServico");
            }
            else
            {
                ViewBag.Servico = servico;
                return View("FormularioServico");
            }
            
        }
    }
}