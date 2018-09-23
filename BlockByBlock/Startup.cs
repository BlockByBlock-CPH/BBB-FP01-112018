using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlockByBlock.Startup))]
namespace BlockByBlock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
