using ChatR.Web.Models;
using ChatR.Web.Services;
using Microsoft.AspNet.SignalR;

namespace ChatR.Web.Hubs
{
    public class ChatRHub : Hub
    {
        private readonly IChatStorage _chatStorage;

        public ChatRHub(IChatStorage chatStorage)
        {
            _chatStorage = chatStorage;
        }

        public void Send(string name, string message)
        {
            _chatStorage.AddMessage(new ChatMessage {Name = name, Text = message});
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}