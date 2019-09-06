using ProjetoBenner.DAO;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class InformacoesSalaoController : Controller
    {
        // GET: HorarioAtendimento
        public ActionResult IndexInformacoesSalao()
        {
            InformacoesSalaoDAO dao = new InformacoesSalaoDAO();
            var dados = dao.Listar();
            ViewBag.Dados = dados;
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarInformacoes(string[] Dados)
        {
            InformacoesSalao dados = new InformacoesSalao();
            dados.Cidade = Dados[0];
            dados.CEP = Dados[1];
            dados.Rua = Dados[2];
            dados.Numero = Dados[3];
            dados.Telefone = Dados[4];
            dados.Email = Dados[5];

            if (dados.Cidade == null || dados.CEP == null)
            {
                ModelState.AddModelError("dados.Adicionar", "Estes campos são obrigatórios");
            }
            if (ModelState.IsValid)
            {
                InformacoesSalaoDAO dao = new InformacoesSalaoDAO();
                dao.CadastrarInformacoes(dados);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult ListarDados(int id)
        {
            InformacoesSalaoDAO dao = new InformacoesSalaoDAO();
            InformacoesSalao resposta = dao.Listar();
            return Json(resposta);
        }

        public ActionResult AtualizarDados(string[] Dados, int Id)
        {
            InformacoesSalaoDAO dao = new InformacoesSalaoDAO();
            InformacoesSalao dados = dao.BuscarInformacoesId(Id);
            dados.Cidade = Dados[0];
            dados.CEP = Dados[1];
            dados.Rua = Dados[2];
            dados.Numero = Dados[3];
            dados.Telefone = Dados[4];
            dados.Email = Dados[5];

            dao.AtualizarInformacoes(dados);

            return Json(true);
        }
    }
}