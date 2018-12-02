using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SportsChatRoom
{
    public class User
    {
        public string Name { get; set; }
        public int  ConnectionId { get; set; }
    }
    [HubName("sportschatroom")]
    public class MainHub : Hub
    {
        public List<User> ConnectedUsers = new List<User>();
        public List<User> messages = new List<User>();
        
        //Client calls this method to join the room. There will be other clients as well in that room
        public void JoinSportRoom(string room,string name)
        {
            Groups.Add(Context.ConnectionId, room);
            Clients.OthersInGroup(room).newUser(name);         
        }
        //Client calls this method to join the room. There will be other clients as well in that room
        public void SendMessageToGroup(string room,string message,string messageSentBy)
        {
            Clients.Group(room).appendMessage(message, messageSentBy);
        }
        public  Task OnConnected() { return null; }

        public  Task OnDisconnected() { return null; }
        public  Task OnReconnected() { return null; }
    }
}