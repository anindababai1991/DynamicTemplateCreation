using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnindaWeb.Startup))]
namespace AnindaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
