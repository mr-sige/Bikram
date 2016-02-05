using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bikram.Startup))]
namespace Bikram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
