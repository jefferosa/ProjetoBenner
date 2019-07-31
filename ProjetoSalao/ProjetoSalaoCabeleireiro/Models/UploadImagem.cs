using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBenner.Models
{
    public class UploadImagem
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}