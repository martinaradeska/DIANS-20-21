using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocalsScout.Startup))]
namespace LocalsScout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
