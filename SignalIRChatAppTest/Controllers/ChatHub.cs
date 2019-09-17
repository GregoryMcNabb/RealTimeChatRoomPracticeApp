using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalIRChatAppTest.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalIRChatAppTest.Controllers
{
    public class ChatHub : Hub
    {
        public void Send(string sentMessage)
        {
            var message = JsonConvert.SerializeObject(new ChatMessage(sentMessage, this));
            Clients.All.broadcast(message);
        }

        public async Task Join(string groupName)
        {
            await Groups.Add(Context.ConnectionId, groupName);
            var message = JsonConvert.SerializeObject(new ChatMessage($"{Context.User.Identity.Name} has joined."));
            Clients.Group(groupName).broadcast(message);
        }

        public void Leave(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
            var message = JsonConvert.SerializeObject(new ChatMessage($"{Context.User.Identity.Name} has left."));
            Clients.OthersInGroup(groupName).broadcast(message);
        }
    }
}