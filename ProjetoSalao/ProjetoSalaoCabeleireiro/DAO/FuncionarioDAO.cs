using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class FuncionarioDAO
    {
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (var context = new SalaoContext())
            {
                context.Funcionarios.Add(funcionario);
                context.SaveChanges();
            }
        }

        public IList<Funcionario> ListarFuncionarios()
        {
            using (var context = new SalaoContext())
            {
                return context.Funcionarios.ToList();
            }
        } 

        public Funcionario BuscarFuncionarioId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Funcionarios.Find(id);
            }
        }

        public Funcionario BuscarUsuario(string login, string senha)
        {
            using (var context = new SalaoContext())
            {
                return context.Funcionarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }

        public void AtualizarFun(Funcionario funcionario)
        {
            using (var context = new SalaoContext())
            {
                context.Funcionarios.Update(funcionario);
                context.SaveChanges();
            }
        }
    }
}