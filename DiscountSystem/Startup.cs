using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiscountSystem.Startup))]
namespace DiscountSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
