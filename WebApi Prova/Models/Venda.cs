using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_Prova.Models
{
    public class Venda
    {
        [Key]
        public int id { get; set; }
        public int idProduto { get; set; }
        public int idCliente { get; set; }
        public float precoVenda { get; set; }
    }
}