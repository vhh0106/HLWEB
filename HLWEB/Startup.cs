using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HLWEB.Startup))]
namespace HLWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
