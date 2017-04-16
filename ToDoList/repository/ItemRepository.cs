using System.Data.Entity;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemRepository : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
    }
}
