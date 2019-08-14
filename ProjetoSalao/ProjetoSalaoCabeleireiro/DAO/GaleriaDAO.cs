using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjetoBenner.DAO
{
    public class GaleriaDAO
    {
        public void AdicionarImagem(UploadImagem uploadImagem)
        {
            Galeria galeria = new Galeria();
            using (var context = new SalaoContext())
            {
                using (var binaryReader = new BinaryReader(uploadImagem.ImageUpload.InputStream))
                {
                    galeria.Imagem = binaryReader.ReadBytes(uploadImagem.ImageUpload.ContentLength);
                    context.Galeria.Add(galeria);
                    context.SaveChanges();
                }
            }
        }

        public IList<Galeria> ListarImagens()
        {
            IList<Galeria> itens = new List<Galeria>();
            using (var context = new SalaoContext())
            {
                return context.Galeria.ToList();
            }
        }

        public Galeria BuscarPorId(int id)
        {
            using (var context = new SalaoContext())
            {
                return context.Galeria.Where(i => i.Id == id)
                    .FirstOrDefault();
            }
        }

        public void AtualizarGaleria(Galeria galeria)
        {
            using (var contexto = new SalaoContext())
            {
                contexto.Galeria.Update(galeria);
                contexto.SaveChanges();
            }
        }
    }
}