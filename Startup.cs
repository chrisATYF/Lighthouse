using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lighthouse.Startup))]
namespace Lighthouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
