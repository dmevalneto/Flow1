using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Flow.Models
{
    public class FlowContext : IdentityDbContext<ApplicationUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FlowContext() : base("name=FlowContext")
        {
        }

        public static FlowContext Create()
        {
            return new FlowContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => i.RoleId);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public System.Data.Entity.DbSet<Flow.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<Flow.Areas.Corporativo.Models.Teste> Testes { get; set; }

        public System.Data.Entity.DbSet<Flow.Models.Conta> Contas { get; set; }

        public System.Data.Entity.DbSet<Flow.Models.Perfil> Perfils { get; set; }

        public System.Data.Entity.DbSet<Flow.Models.Setor> Setors { get; set; }
        
    }
}
