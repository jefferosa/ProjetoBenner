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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult IndexCliente()
        {
            return View();
        }

        public ActionResult PerfilCliente()
        {
            return View("PerfilCliente");
        }

        public ActionResult PerfilFuncionario()
        {
            return View("PerfilFuncionario");
        }
        
        [HttpPost]
        public ActionResult AdicionarCliente(Cliente cliente)
        {
            if (cliente.Nome == null || cliente.CPF == null || cliente.Email == null || cliente.Login == null || cliente.Senha == null)
            {
                ModelState.AddModelError("usuario.CadastroEmBranco", "Não pode cadastrar um usuario em branco");
            }
            if (ModelState.IsValid)
            {
                ClienteDAO daoCliente = new ClienteDAO();
                daoCliente.AdicionarCliente(cliente);
                return RedirectToAction("IndexLogin", "Login");
            }
            else
            {
                ViewBag.Cliente = cliente;
                return RedirectToAction("IndexLogin","Login");
            }
        }

        public ActionResult AdicionarFuncionario(Funcionario funcionario)
        {
            if (funcionario.Nome == null || funcionario.CPF == null || funcionario.Email == null || funcionario.Login == null || funcionario.Senha == null)
            {
                ModelState.AddModelError("usuario.CadastroEmBranco", "Não pode cadastrar um usuario em branco");
            }
            if (ModelState.IsValid)
            {
                FuncionarioDAO daoFuncionario = new FuncionarioDAO();
                daoFuncionario.AdicionarFuncionario(funcionario);
                return RedirectToAction("IndexLogin", "Login");
            }
            else
            {
                ViewBag.Funcionario = funcionario;
                return RedirectToAction("IndexLogin", "Login");
            }
        }

        [AutorizacaoFuncionario]
        public ActionResult AtualizarFuncionario(string[] Dados, int Id)
        {
            FuncionarioDAO daoFuncionario = new FuncionarioDAO();
            Funcionario dados = daoFuncionario.BuscarFuncionarioId(Id);

            dados.Nome = Dados[0];
            dados.CPF = Dados[1];
            dados.Telefone = Dados[2];
            dados.Email = Dados[3];
            dados.CEP = Dados[4];
            dados.Cidade = Dados[5];
            dados.Bairro = Dados[6];
            dados.Rua = Dados[7];

            daoFuncionario.AtualizarFun(dados);

            return Json(true);
        }

        public ActionResult AtualizarCliente(string[] Dados, int Id)
        {
            ClienteDAO daoCliente = new ClienteDAO();
            Cliente dados = daoCliente.BuscarClienteId(Id);

            dados.Nome = Dados[0];
            dados.CPF = Dados[1];
            dados.Telefone = Dados[2];
            dados.Email = Dados[3];
            dados.CEP = Dados[4];
            dados.Cidade = Dados[5];
            dados.Bairro = Dados[6];
            dados.Rua = Dados[7];

            daoCliente.AtualizarCli(dados);

            return Json(true);
        }

        [AutorizacaoFilter]
        public ActionResult AgendamentosCliente()
        {
            AgendaDAO daoAgenda = new AgendaDAO();
            var agendamentos = daoAgenda.ListarAgendamentos();
            ViewBag.Agendamentos = agendamentos;

            return View();
        }
    }
}