﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBenner.Models
{
    public class Galeria
    {
        public int Id { get; set; }

        public Byte[] Imagem { get; set; }
    }
}