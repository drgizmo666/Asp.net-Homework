using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentralCity.Startup))]
namespace CentralCity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
