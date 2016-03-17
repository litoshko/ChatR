using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatR.Web.Startup))]
namespace ChatR.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuartion should go here
            app.MapSignalR();
        }
    }
}