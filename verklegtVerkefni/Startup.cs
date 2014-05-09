using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(verklegtVerkefni.Startup))]
namespace verklegtVerkefni
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
