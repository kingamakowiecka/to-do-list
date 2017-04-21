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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                        .HasOptional(i => i.ItemNotification)
                        .WithRequired(n => n.Item)
                        .WillCascadeOnDelete(true);
        }
    }
}
