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
    
    public class InformacoesSalaoController : Controller
    {
        [AutorizacaoFuncionario]
        public ActionResult IndexInformacoesSalao()
        {
            InformacoesSalaoDAO daoInformacoesSalao = new InformacoesSalaoDAO();
            var dados = daoInformacoesSalao.ListarDados();
            ViewBag.Dados = dados;
            return View();
        }

        [AutorizacaoFuncionario]
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
                InformacoesSalaoDAO daoInformacoesSalao = new InformacoesSalaoDAO();
                daoInformacoesSalao.CadastrarInformacoes(dados);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult ListarDados(int id)
        {
            InformacoesSalaoDAO daoInformacoesSalao = new InformacoesSalaoDAO();
            InformacoesSalao resposta = daoInformacoesSalao.Listar();
            return Json(resposta);
        }

        [AutorizacaoFuncionario]
        public ActionResult AtualizarDados(string[] Dados, int Id)
        {
            InformacoesSalaoDAO daoInformacoesSalao = new InformacoesSalaoDAO();
            InformacoesSalao dados = daoInformacoesSalao.BuscarInformacoesId(Id);
            dados.Cidade = Dados[0];
            dados.CEP = Dados[1];
            dados.Rua = Dados[2];
            dados.Numero = Dados[3];
            dados.Telefone = Dados[4];
            dados.Email = Dados[5];

            daoInformacoesSalao.AtualizarInformacoes(dados);

            return Json(true);
        }
    }
}