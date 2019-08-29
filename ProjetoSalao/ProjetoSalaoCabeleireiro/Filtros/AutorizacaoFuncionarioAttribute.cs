using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace ProjetoBenner.Filtros
{
    public class AutorizacaoFuncionarioAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuarioLogado = filterContext.HttpContext.Session["FuncionarioLogado"];
            if (usuarioLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "IndexLogin", controller = "Login" })
                );
            }
        }
    }
}