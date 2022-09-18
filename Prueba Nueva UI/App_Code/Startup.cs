using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prueba_Nueva_UI.Startup))]
namespace Prueba_Nueva_UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
