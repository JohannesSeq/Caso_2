using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caso__2App.Startup))]
namespace Caso__2App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
