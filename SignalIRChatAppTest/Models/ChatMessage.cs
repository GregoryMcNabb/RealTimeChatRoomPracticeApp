using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalIRChatAppTest.Models
{
    public class ChatMessage
    {
        public ChatMessage(string message)
        {
            Message = message;
            Username = "System";
            Date = DateTime.UtcNow;
        }
        public ChatMessage(string message, Hub hub)
        {
            Message = message;
            Username = hub.Context.User.Identity.Name;
            Date = DateTime.UtcNow;
        }
        public string Message { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
    }
}