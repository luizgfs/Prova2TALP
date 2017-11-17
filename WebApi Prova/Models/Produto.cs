using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_Prova.Models
{
    public class Produto
    {
        [Key]
        public int id { get; set; }
        public string produto { get; set; }
        public int qtdEstoque { get; set; }
        public float preco { get; set; }
        public float custo { get; set; }
    }
}