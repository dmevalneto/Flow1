using Flow.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Flow
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.FlowContext, Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();
            CriarRoles(db);
            CriarSuperUser(db);
            AddPermissoesSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermissoesSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("superusuario@flow.com");
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!userManager.IsInRole(user.Id, "Criar"))
            {
                userManager.AddToRole(user.Id, "Criar");
            }
            if (!userManager.IsInRole(user.Id, "Visualizar"))
            {
                userManager.AddToRole(user.Id, "Visualizar");
            }
            if (!userManager.IsInRole(user.Id, "Editar"))
            {
                userManager.AddToRole(user.Id, "Editar");
            }
            if (!userManager.IsInRole(user.Id, "Deletar"))
            {
                userManager.AddToRole(user.Id, "Deletar");
            }
            if (!userManager.IsInRole(user.Id, "Corporativo"))
            {
                userManager.AddToRole(user.Id, "Corporativo");
            }
        }

        private void CriarSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("superusuario@flow.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "superusuario@flow.com",
                    Email = "superusuario@flow.com",
                };
                userManager.Create(user, "SuperUsuario@123");
            }
        }

        private void CriarRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists("Criar"))
            {
                roleManager.Create(new IdentityRole("Criar"));
            }
            if (!roleManager.RoleExists("Visualizar"))
            {
                roleManager.Create(new IdentityRole("Visualizar"));
            }
            if (!roleManager.RoleExists("Editar"))
            {
                roleManager.Create(new IdentityRole("Editar"));
            }
            if (!roleManager.RoleExists("Deletar"))
            {
                roleManager.Create(new IdentityRole("Deletar"));
            }
            if (!roleManager.RoleExists("Corporativo"))
            {
                roleManager.Create(new IdentityRole("Corporativo"));
            }
        }
    }
}
