using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Choose.MobileAppService.Startup))]

namespace Choose.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}