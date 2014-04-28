using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Invensoft.Startup))]
namespace Invensoft
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
