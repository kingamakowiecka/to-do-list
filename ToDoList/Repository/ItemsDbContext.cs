using System.Data.Common;
using System.Data.Entity;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext() { }

        public ItemsDbContext(DbConnection connection) : base(connection, true) { }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemNotification> ItemNotifications { get; set; }
    }
}
