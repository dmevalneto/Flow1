using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Flow.Startup))]
namespace Flow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
