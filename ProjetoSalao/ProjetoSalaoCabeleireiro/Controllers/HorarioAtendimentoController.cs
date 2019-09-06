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
    [AutorizacaoFuncionario]
    public class HorarioAtendimentoController : Controller
    {
        // GET: HorarioAtendimento
        public ActionResult Index()
        {
            HorarioAtendimentoDAO dao = new HorarioAtendimentoDAO();
            IList<HorarioAtendimento> horarios = dao.ListarHorarioAtendimento();
            ViewBag.HorarioAtendimento = horarios;
            return View("Index");
        }

        [HttpPost]
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
                HorarioAtendimentoDAO dao = new HorarioAtendimentoDAO();
                string valida = (dao.AdicionarHorarioAtendimento(horario)) ? "Sim" : "Não";
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
            HorarioAtendimentoDAO dao = new HorarioAtendimentoDAO();
            HorarioAtendimento resposta = dao.ListarHorarios();
            return Json(resposta);
        }

        public ActionResult AtualizarHorario (DateTime HoraA, DateTime HoraB, int Id)
        {
            HorarioAtendimentoDAO dao = new HorarioAtendimentoDAO();
            HorarioAtendimento horarios = dao.BuscarHorariosId(Id);
            horarios.HorarioAbertura = HoraA;
            horarios.HorarioFechamento = HoraB;
            dao.AtualizarHorarioAtendimento(horarios);

            return Json(true);
        }
    }
}