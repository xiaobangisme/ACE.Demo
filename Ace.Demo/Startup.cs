using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ace.Demo.Startup))]
namespace Ace.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
