using ProjetoBenner.DAO;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulario()
        {
            ViewBag.Agenda = new Agenda();
            ServicoDAO dao = new ServicoDAO();
            IList<Servico> servico = dao.ListaServicos();
            ViewBag.Servico = servico;
            return View(servico);
        }

        [HttpPost]
        public ActionResult AgendarHorario(Agenda agenda)
        {
            if (agenda.Data == null || agenda.Horario == null || agenda.ServicoId == null)
            {
                ModelState.AddModelError("agenda.CadastroEmBranco", "Não pode cadastrar um horário em branco");
            }
            if (ModelState.IsValid)
            {
                AgendaDAO dao = new AgendaDAO();
                dao.AgendarHorario(agenda);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Agenda = agenda;
                ServicoDAO servicoDAO = new ServicoDAO();
                ViewBag.Servico = servicoDAO.ListaServicos();
                return View("Formulario");
            }
        }
    }
}