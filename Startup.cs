using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Archive_of_views.Startup))]
namespace Archive_of_views
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
