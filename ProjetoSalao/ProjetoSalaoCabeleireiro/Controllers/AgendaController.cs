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
            AgendaDAO daoAgenda = new AgendaDAO();
            var horarios = daoAgenda.ListarHorarioAtendimento();
            ViewBag.Horarios = horarios;

            var agendamentos = daoAgenda.ListarAgendamentos();
            ViewBag.Cont = agendamentos.Count();
            ViewBag.Agenda = agendamentos;

            ServicoDAO daoS = new ServicoDAO();
            var servico = daoS.ListaServicos();
            ViewBag.Servico = servico;

            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();
            var funcionarios = daoFuncionarios.ListarFuncionarios();
            int cont = funcionarios.Count();
            ViewBag.ContFun = cont;

            var DiasDaSemana = new DiasDaSemana();
            ViewBag.DiasDaSemana = DiasDaSemana;

            return View(horarios);
        }

        [AutorizacaoFuncionario]
        public ActionResult IndexAgendaFuncionario()
        {
            AgendaDAO daoAgenda = new AgendaDAO();
            var horarios = daoAgenda.ListarHorarioAtendimento();
            ViewBag.Horarios = horarios;

            var agendamentos = daoAgenda.ListarAgendamentos();
            ViewBag.Cont = agendamentos.Count();
            ViewBag.Agenda = agendamentos;

            ServicoDAO daoServico = new ServicoDAO();
            var servico = daoServico.ListaServicos();
            ViewBag.Servico = servico;

            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();
            var funcionarios = daoFuncionarios.ListarFuncionarios();
            int cont = funcionarios.Count();
            ViewBag.ContFun = cont;

            return View(horarios);
        }

        public ActionResult Agendamentos()
        {
            AgendaDAO daoAgenda = new AgendaDAO();
            var agendamentos = daoAgenda.ListarAgendamentos();
            ViewBag.Agenda = agendamentos;
            return View(agendamentos);
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
            var funcionarios = daoFuncionarios.ListarFuncionarios();
            int cont = funcionarios.Count();
            ViewBag.Cont = cont;

            AgendaDAO daoAgenda = new AgendaDAO();
            int agendaProcura = daoAgenda.BuscarAgendamento(agenda.Horario, agenda.Data);

            ViewBag.AgendamentoC = agendaProcura;

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
                return Json(daoAgenda.AgendarHorario(agenda));
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