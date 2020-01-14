using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourStore.WebUI.Startup))]
namespace TourStore.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
