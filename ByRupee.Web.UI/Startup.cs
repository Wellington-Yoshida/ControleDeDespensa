using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ByRupee.Web.UI.Startup))]
namespace ByRupee.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
