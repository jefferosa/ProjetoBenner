using ProjetoBenner.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class LucroAgendamentoController : Controller
    {
        // GET: ControleFinanceiro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdicionarEntrada(DateTime Data, Double Valor)
        {
            LucroAgendamento lucroAgendamento = new LucroAgendamento();
            lucroAgendamento.DataEntrada = Data;
            lucroAgendamento.ValorEntrada = Valor;

            LucroAgendamentoDAO daoLucro = new LucroAgendamentoDAO();
            daoLucro.AdicionarEntrada(lucroAgendamento);
            
            var resposta = daoLucro.LucroMensal();

            return Json(resposta);
        }
    }
}