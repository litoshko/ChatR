using Microsoft.AspNet.SignalR;

namespace ChatR.Web.Hubs
{
    public class ChatRHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}