using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InmateTest.Startup))]
namespace InmateTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
