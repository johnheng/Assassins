using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assassins.Startup))]
namespace Assassins
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
