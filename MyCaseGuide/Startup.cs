using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCaseGuide.Startup))]
namespace MyCaseGuide
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
