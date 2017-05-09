using getadoc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(getadoc.Startup))]
namespace getadoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            createRolesandUsers();
            ConfigureAuth(app);
        }
        public void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.Email = "abc@xyz.in";
                user.UserName = "abc@xyz.in";
                string userPWD = "Abc!@#123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Doctors"))
            {
                var role = new IdentityRole();
                role.Name = "Doctors";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Patients"))
            {
                var role = new IdentityRole();
                role.Name = "Patients";
                roleManager.Create(role);

            }

        }
    }
}
