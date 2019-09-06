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
    
    public class AgendaController : Controller
    {
        // GET: Agenda

        [AutorizacaoFilter]
        public ActionResult IndexAgenda()
        {
            AgendaDAO dao = new AgendaDAO();
            var horarios = dao.Listar();
            ViewBag.Horarios = horarios;

            ServicoDAO daoS = new ServicoDAO();
            var servico = daoS.ListaServicos();
            ViewBag.Servico = servico;

            var agendamentos = dao.ListarAgendamentos();
            ViewBag.Cont = agendamentos.Count();
            ViewBag.Agenda = agendamentos;

            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();
            IList<Funcionario> funcionarios = daoFuncionarios.ListarFuncionarios();
            int cont = funcionarios.Count();

            var DiasDaSemana = new DiasDaSemana();
            ViewBag.DiasDaSemana = DiasDaSemana;

            ViewBag.ContFun = cont;

            return View(horarios);
        }

        [AutorizacaoFuncionario]
        public ActionResult IndexAgendaFuncionario()
        {
            AgendaDAO dao = new AgendaDAO();
            var horarios = dao.Listar();
            ViewBag.Horarios = horarios;

            ServicoDAO daoS = new ServicoDAO();
            var servico = daoS.ListaServicos();
            ViewBag.Servico = servico;

            var agendamentos = dao.ListarAgendamentos();
            ViewBag.Cont = agendamentos.Count();
            ViewBag.Agenda = agendamentos;

            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();
            IList<Funcionario> funcionarios = daoFuncionarios.ListarFuncionarios();
            int cont = funcionarios.Count();

            ViewBag.ContFun = cont;

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
            agenda.Estado = "Agendado";

            ViewBag.Agenda = agenda;
            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();

            IList<Funcionario> funcionarios = daoFuncionarios.ListarFuncionarios();
            int cont = funcionarios.Count();

            AgendaDAO daoProcura = new AgendaDAO();
            int agendaProcura = daoProcura.BuscarAgendamento(agenda.Horario, agenda.Data);

            ViewBag.AgendamentoC = agendaProcura;
            ViewBag.Cont = cont;

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