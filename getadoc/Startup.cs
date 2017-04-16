using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(getadoc.Startup))]
namespace getadoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
