using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_13.MVC_Blog.Startup))]
namespace _13.MVC_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
