using ProjetoBenner.DAO;
using ProjetoBenner.Filtros;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class GaleriaController : Controller
    {
        [HttpGet]
        public ActionResult IndexGaleria()
        {
            GaleriaDAO dao = new GaleriaDAO();
            var imagens = dao.ListarImagens();
            ViewBag.Galeria = imagens;
            return View(imagens);
        }

        [HttpGet]
        [AutorizacaoFuncionario]
        public ActionResult GaleriaFuncionario()
        {
            GaleriaDAO dao = new GaleriaDAO();
            var imagens = dao.ListarImagens();
            ViewBag.Galeria = imagens;
            return View(imagens);
        }

        [HttpPost]
        [AutorizacaoFuncionario]
        public ActionResult AdicionarImagem(UploadImagem uploadImagem)
        {
            Galeria galeria = new Galeria();
            var imageTypes = new string[]{
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };

            if (uploadImagem.ImageUpload == null || uploadImagem.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            }
            else if (!imageTypes.Contains(uploadImagem.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Escolha uma iamgem JPG ou PNG.");
            }
            if (ModelState.IsValid)
            {
                GaleriaDAO dao = new GaleriaDAO();
                dao.AdicionarImagem(uploadImagem);
                return RedirectToAction("GaleriaFuncionario");
            }
            else
            {
                ViewBag.Galeria = galeria;
                return View(uploadImagem);
            }
        }

        [AutorizacaoFuncionario]
        public ActionResult RemoverImagens(int id)
        {
            GaleriaDAO dao = new GaleriaDAO();
            dao.RemoverImagem(id);
            return Json(id);
        }
    }
}