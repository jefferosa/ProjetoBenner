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
    
    public class HorarioAtendimentoController : Controller
    {
        // GET: HorarioAtendimento
        [AutorizacaoFuncionario]
        public ActionResult Index()
        {
            HorarioAtendimentoDAO daoHorarioAtendimento = new HorarioAtendimentoDAO();
            var horarios = daoHorarioAtendimento.ListarHorarioAtendimento();
            ViewBag.HorarioAtendimento = horarios;
            return View("Index");
        }

        [HttpPost]
        [AutorizacaoFuncionario]
        public ActionResult AdicionarHorarioAtendimento(DateTime HoraA, DateTime HoraB)
        {
            HorarioAtendimento horario = new HorarioAtendimento();
            horario.HorarioAbertura = HoraA;
            horario.HorarioFechamento = HoraB;
            if (horario.HorarioAbertura == null || horario.HorarioFechamento == null)
            {
                ModelState.AddModelError("horario.Adicionar", "Estes campos são obrigatórios");
            }
            if (ModelState.IsValid)
            {
                HorarioAtendimentoDAO daoHorarioAtendimento = new HorarioAtendimentoDAO();
                string valida = (daoHorarioAtendimento.AdicionarHorarioAtendimento(horario)) ? "Sim" : "Não";
                return Json(valida);
            }
            else
            {
                ViewBag.HorarioAtendimento = horario;
                return View("Index");
            }
        }

        public ActionResult ListarHorarios(int id)
        {
            HorarioAtendimentoDAO daoHorarioAtendimento = new HorarioAtendimentoDAO();
            HorarioAtendimento resposta = daoHorarioAtendimento.ListarHorarios();
            return Json(resposta);
        }

        [AutorizacaoFuncionario]
        public ActionResult AtualizarHorario (DateTime HoraA, DateTime HoraB, int Id)
        {
            HorarioAtendimentoDAO daoHorarioAtendimento = new HorarioAtendimentoDAO();
            HorarioAtendimento horarios = daoHorarioAtendimento.BuscarHorariosId(Id);
            horarios.HorarioAbertura = HoraA;
            horarios.HorarioFechamento = HoraB;
            daoHorarioAtendimento.AtualizarHorarioAtendimento(horarios);

            return Json(true);
        }
    }
}