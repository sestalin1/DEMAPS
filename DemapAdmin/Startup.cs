using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemapAdmin.Startup))]
namespace DemapAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
