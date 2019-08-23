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
            using (var context = new SalaoContext())
            {
                context.Entry(galeria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void RemoverImagem(int id)
        {
            using (var context = new SalaoContext())
            {
                var img = context.Galeria.First(i => i.Id == id);
                context.Galeria.Remove(img);
                context.SaveChanges();
            }
        }
    }
}