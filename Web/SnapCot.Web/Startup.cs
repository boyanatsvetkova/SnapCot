using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SnapCot.Web.Startup))]

namespace SnapCot.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
