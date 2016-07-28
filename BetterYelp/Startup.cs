using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BetterYelp.Startup))]
namespace BetterYelp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
