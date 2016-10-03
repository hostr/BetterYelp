using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeShouldGo.Startup))]
namespace WeShouldGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
