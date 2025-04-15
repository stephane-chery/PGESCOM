using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PGCWEB.Startup))]
namespace PGCWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
