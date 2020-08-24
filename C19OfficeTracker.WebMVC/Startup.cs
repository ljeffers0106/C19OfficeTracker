using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(C19OfficeTracker.WebMVC.Startup))]
namespace C19OfficeTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
