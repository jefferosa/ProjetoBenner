using Microsoft.EntityFrameworkCore;
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
            AgendaDAO daoAgenda = new AgendaDAO();

            var agendamentos = daoAgenda.ListarAgendamentos();
            ViewBag.Agendamentos = agendamentos;

            var horarios = daoAgenda.ListarHorarioAtendimento();
            ViewBag.Horarios = horarios;

            var qtdAgendamentos = daoAgenda.ContaAgendamentos();
            ViewBag.Agenda = qtdAgendamentos;

            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();
            var funcionarios = daoFuncionarios.ListarFuncionarios();
            ViewBag.contaFun = funcionarios.Count();

            LucroAgendamentoDAO Lucro = new LucroAgendamentoDAO();
            ViewBag.LucroMensal = Lucro.LucroMensal();

            return View(agendamentos);
        }

        public ActionResult AtualizarEstado(int id, string estado)
        {
            AgendaDAO dao = new AgendaDAO();
            Agenda agendamento = dao.BuscarAgendamentoId(id);
            agendamento.Estado = estado;
            if (estado == "Cancelado")
            {
                dao.RemoverHorario(agendamento);
            }
            else
            {
                dao.AtualizarAgendamento(agendamento);
            }

            return Json(true);
        }

        public ActionResult Layout()
        {
            HorarioAtendimentoDAO dao = new HorarioAtendimentoDAO();
            var horarios = dao.ListarHorarioAtendimento();
            ViewBag.HorarioAtendimento = horarios;

            return View(horarios);
        }
    }
}