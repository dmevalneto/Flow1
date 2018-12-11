using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flow.Models
{
    public class Conta
    {
        [Key]
        public int ContaId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Perfil> Perfil { get; set; }
    }
}