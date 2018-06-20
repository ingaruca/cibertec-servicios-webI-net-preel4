using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServicioWCF.Startup))]
namespace ServicioWCF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
