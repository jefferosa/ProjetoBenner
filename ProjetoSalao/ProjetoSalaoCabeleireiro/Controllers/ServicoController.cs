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
    public class ServicoController : Controller
    {
        // GET: Servico
        public ActionResult IndexServico()
        {
            ServicoDAO daoServico = new ServicoDAO();
            var servicos = daoServico.ListaServicos();
            ViewBag.Servico = servicos;

            return View();
        }

        public ActionResult FormularioServico()
        {
            ViewBag.Servico = new Servico();
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarServico(Servico servico)
        {
            if (servico.Tipo == null || servico.Tempo == 0 || servico.Valor == 0)
            {
                ModelState.AddModelError("servico.CadastroComValorNulo", "Não pode cadastrar um serviço nulo");
            }
            if (ModelState.IsValid)
            {
                ServicoDAO daoServico = new ServicoDAO();
                daoServico.AdicionarServico(servico);
                return RedirectToAction("IndexServico");
            }
            else
            {
                ViewBag.Servico = servico;
                return View("IndexServico");
            }
        }

        public ActionResult AtualizarServico(string tipo, double valor, int Id)
        {
            ServicoDAO daoServico = new ServicoDAO();
            Servico servicos = daoServico.BuscarServicoId(Id);
            servicos.Tipo = tipo;
            servicos.Valor = valor;

            daoServico.AtualizarServico(servicos);

            return Json(true);
        }
    }
}