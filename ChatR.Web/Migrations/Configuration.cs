using System.Globalization;
using ChatR.Web.Models;

namespace ChatR.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChatR.Web.Models.ChatDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChatR.Web.Models.ChatDbContext context)
        {
            var format = "dd/MM/yyyy hh:mm";
            var culture = CultureInfo.InvariantCulture;
            context.ChatMessages.AddOrUpdate(
                new ChatMessage { DateTime = DateTime.ParseExact("15/04/2016 08:30", format, culture), Name = "Andrii", Text = "Hello!"},
                new ChatMessage { DateTime = DateTime.ParseExact("15/04/2016 08:31", format, culture), Name = "Oleksii", Text = "Hi!"},
                new ChatMessage { DateTime = DateTime.ParseExact("15/04/2016 08:34", format, culture), Name = "Sergii", Text = "How are you?"}
                );
            context.SaveChanges();
        }
    }
}
