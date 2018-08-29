using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nabil.Startup))]
namespace Nabil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
