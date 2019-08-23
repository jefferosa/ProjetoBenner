using ProjetoBenner.DAO;
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
                string valida = (dao.AdicionarHorarioAtendimento(horario))?"Sim":"Não";
                return Json(valida);
            }
            else
            {
                ViewBag.HorarioAtendimento = horario;
                return View("Index");
            }
        }
    }
}