namespace getadoc.Migrations
{
    using getadoc.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using getadoc.Models.DbContexts;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "getadoc.Models.DbContexts.DataContexts";
        }

        protected override void Seed(ApplicationDbContext context)
        {
           if(!context.Users.Any(u => u.Email=="abc@xyz.in"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { Email = "abc@xyz.in" };
                var role = new RoleStore<IdentityRole>(context);
                var rolemanager = new RoleManager<IdentityRole>(role);
                rolemanager.Create(new IdentityRole { Name = "admin" });
                manager.Create(user, "ABC!@#123");
                manager.AddToRole(user.Email, "admin");
            }
        }
    }
}
