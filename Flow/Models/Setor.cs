using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flow.Models
{
    public class Setor
    {
        [Key]
        public int SetorId { get; set; }
        public string Nome { get; set; }

        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}