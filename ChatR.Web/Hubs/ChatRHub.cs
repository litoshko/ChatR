using Microsoft.AspNet.SignalR;

// ReSharper disable once CheckNamespace
namespace ChatR.Web
{
    public class ChatRHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}