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
            var db = new SalaoContext();
            AgendaDAO dao = new AgendaDAO();
            var agendamentos = dao.ListarAgendamentos();

            ViewBag.Agendamentos = agendamentos;

            AgendaDAO daoHor = new AgendaDAO();
            var horarios = daoHor.Listar();
            ViewBag.Horarios = horarios;

            FuncionarioDAO daoFuncionarios = new FuncionarioDAO();
            var funcionarios = daoFuncionarios.ListarFuncionarios();
            ViewBag.contFun = funcionarios.Count();

            var lista = (IList<EstadoAtendimento>)Enum.GetValues(typeof(EstadoAtendimento));
            ViewBag.ListaEstado = lista;

            ViewBag.Agenda = agendamentos.Count();

            LucroAgendamentoDAO lucro = new LucroAgendamentoDAO();
            var LucrosLista = lucro.ListarEntradas();
            
            ViewBag.LucroMensal = lucro.LucroMensal();

            return View(agendamentos);
        }

        public ActionResult AtualizarEstado(int id, string estado)
        {
            AgendaDAO dao = new AgendaDAO();
            Agenda agendamento = dao.BuscarAgendamentoId(id);
            agendamento.Estado = estado;
            if(estado == "Cancelado")
            {
                dao.RemoverHorario(agendamento);
            }
            else
            {
                dao.AtualizarAgendamento(agendamento);
            }
            
            return Json(true);
        }
    }
}