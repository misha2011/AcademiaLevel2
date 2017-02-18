using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademiaLevel2.Startup))]
namespace AcademiaLevel2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}