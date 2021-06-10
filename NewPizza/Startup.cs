using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewPizza.Startup))]
namespace NewPizza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
