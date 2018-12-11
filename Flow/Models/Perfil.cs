using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flow.Models
{
    public class Perfil
    {
        [Key]
        public int PerfilId { get; set; }
        public string Nome { get; set; }

        public int ContaId { get; set; }
        public virtual Conta Conta { get; set; }

        public virtual ICollection<Setor> Setor { get; set; }
    }
}