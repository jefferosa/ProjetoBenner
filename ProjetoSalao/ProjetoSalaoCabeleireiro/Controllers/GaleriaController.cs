using ProjetoBenner.DAO;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class GaleriaController : Controller
    {
        // GET: Galeria
        //public ActionResult IndexGaleria()
        //{
        //    GaleriaDAO dao = new GaleriaDAO();
        //    IList<Galeria> imagens = dao.ListarImagens();
        //    ViewBag.Produto = imagens;
        //    return View("IndexGaleria");
        //}

        //public ActionResult FormularioGaleria()
        //{

        //}

        //public ActionResult AdicionarImagem(Galeria galeria)
        //{
        //    if ()
        //    {
        //        ModelState.AddModelError("imagem.CadastroEmBranco", "Não pode cadastrar uma imagem vazia");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        GaleriaDAO dao = new GaleriaDAO();
        //        dao.AdicionarImagem(galeria);
        //        return RedirectToAction("IndexGaleria");
        //    }
        //    else
        //    {
        //        ViewBag.Galeria = galeria;
        //        return View("FormularioGaleria");
        //    }
        //}
    }
}