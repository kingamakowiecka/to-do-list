using System.Data.Common;
using System.Data.Entity;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext() { }

        public ItemDbContext(DbConnection connection) : base(connection, true) { }

        public virtual DbSet<Item> Items { get; set; }
    }
}
