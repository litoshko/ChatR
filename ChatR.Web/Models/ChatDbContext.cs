using System.Data.Entity;

namespace ChatR.Web.Models
{
    public class ChatDbContext : DbContext
    {
        // Your context has been configured to use a 'ChatDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ChatR.Web.ChatDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ChatDbContext' 
        // connection string in the application configuration file.
        public ChatDbContext()
            : base("name=ChatDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}