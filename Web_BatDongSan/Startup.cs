using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_BatDongSan.Startup))]
namespace Web_BatDongSan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
