using System.Collections.Generic;
using ChatR.Web.Models;

namespace ChatR.Web.Services
{
    public interface IChatStorage
    {
        void AddMessage(ChatMessage message);
        IEnumerable<ChatMessage> GetAllMessages();
    }
}
