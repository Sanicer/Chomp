using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chomp.Startup))]
namespace Chomp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
