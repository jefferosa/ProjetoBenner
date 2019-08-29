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
    [AutorizacaoFilter]
    public class AgendaController : Controller
    {
        // GET: Agenda
        
        public ActionResult IndexAgenda()
        {
            AgendaDAO dao = new AgendaDAO();
            var horarios = dao.Listar();
            ViewBag.Agenda = new Agenda();
            ServicoDAO daoS = new ServicoDAO();
            IList<Servico> servico = daoS.ListaServicos();


            //var agendamentos = dao.ListarAgendamentos();
            //ViewBag.Agenda = agendamentos;
            ViewBag.Servico = servico;
            return View(horarios);
        }

        public ActionResult Agendamentos()
        {
            AgendaDAO dao = new AgendaDAO();
            IList<Agenda> agendamentos = dao.ListarAgendamentos();
            ViewBag.Agenda = agendamentos;
            return View(agendamentos);
        }
        
        public ActionResult FormularioAgenda()
        {
            ViewBag.Agenda = new Agenda();
            ServicoDAO dao = new ServicoDAO();
            IList<Servico> servico = dao.ListaServicos();
            ViewBag.Servico = servico;
            return View(servico);
        }
        
        [HttpPost]
        public ActionResult AgendarHorario(DateTime HoraSelecionada, DateTime Data, int ServicoId, int ClienteId)
        {
            Agenda agenda = new Agenda();
            agenda.Horario = HoraSelecionada;
            agenda.Data = Data;
            agenda.ServicoId = ServicoId;
            agenda.ClienteId = ClienteId;

            ViewBag.Agenda = agenda;
            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();

            IList<Funcionario> funcionarios = daoFuncionarios.ListarFuncionarios();
            int cont = funcionarios.Count();

            AgendaDAO daoProcura = new AgendaDAO();
            int agendaProcura = daoProcura.BuscarAgendamento(agenda.Horario, agenda.Data);

            if (agenda.Data == null || agenda.Horario == null || agenda.ServicoId == null)
            {
                ModelState.AddModelError("agenda.CadastroEmBranco", "Não pode cadastrar um horário em branco");
            }
            if (agendaProcura == cont)
            {
                return Json(false);
            }
            if (ModelState.IsValid)
            {
                AgendaDAO dao = new AgendaDAO();
                return Json(dao.AgendarHorario(agenda));
            }
            else
            {
                ViewBag.Agenda = agenda;
                ServicoDAO servicoDAO = new ServicoDAO();
                ViewBag.Servico = servicoDAO.ListaServicos();
                return View("IndexAgenda");
            }
        }
    }
}