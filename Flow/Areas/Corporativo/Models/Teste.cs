using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flow.Areas.Corporativo.Models
{
    public class Teste
    {
        [Key]
        public int ID { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UltimaCompra { get; set; }
        public float Estoque { get; set; }
    }
}