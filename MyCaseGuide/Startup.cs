using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MyCaseGuide.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCaseGuide.Startup))]
namespace MyCaseGuide
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }
        private void CreateRoles()
        {
            var roleNameAdmin = "Administrator";
            var roleNameAttorney = "Attorney";
            var roleNameLawyer = "Lawyer";
            var roleNameUser = "User";

            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(roleNameAdmin))
            {
                var role = new IdentityRole();
                role.Name = roleNameAdmin;
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(roleNameAttorney))
            {
                var role = new IdentityRole();
                role.Name = roleNameAttorney;
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(roleNameLawyer))
            {
                var role = new IdentityRole();
                role.Name = roleNameLawyer;
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(roleNameUser))
            {
                var role = new IdentityRole();
                role.Name = roleNameUser;
                roleManager.Create(role);
            }
        }
    }
}
