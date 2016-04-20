using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatR.Web.Models;

namespace ChatR.Web.Services
{
    public class ChatStorage: IChatStorage
    {
        private readonly ChatDbContext _chatDbContext;

        public ChatStorage(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public void AddMessage(ChatMessage message)
        {
            message.DateTime = DateTime.Now;
            _chatDbContext.ChatMessages.Add(message);
            _chatDbContext.SaveChanges();
        }

        public IEnumerable<ChatMessage> GetAllMessages()
        {
            var returnValue = _chatDbContext.ChatMessages.ToList();
            return returnValue;

        }
    }
}