using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Pezeshkan.Startup))]

namespace Pezeshkan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
