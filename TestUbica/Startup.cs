using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestUbica.Startup))]
namespace TestUbica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
