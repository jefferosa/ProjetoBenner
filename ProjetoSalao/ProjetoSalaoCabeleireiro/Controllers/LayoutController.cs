using ProjetoBenner.DAO;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public abstract class LayoutController : Controller
    {
        [ChildActionOnly]
        public ActionResult Layout()
        {
            HorarioAtendimentoDAO dao = new HorarioAtendimentoDAO();
            var horarios = dao.ListarHorarioAtendimento();
            ViewBag.HorarioAtendimento = horarios;

            return PartialView(horarios);
        } 
    }
}