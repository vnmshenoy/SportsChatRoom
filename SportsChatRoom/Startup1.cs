using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SportsChatRoom.Startup1))]

namespace SportsChatRoom
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            
                app.MapSignalR();
            
        }
    }
}
