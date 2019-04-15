using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoletoTeste.Startup))]
namespace BoletoTeste
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
