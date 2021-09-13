using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoneBook2.Startup))]
namespace PhoneBook2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
