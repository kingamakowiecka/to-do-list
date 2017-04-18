using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemRepository : IItemRepository
    {
        private ItemDbContext ItemDbContext;

        public ItemRepository(ItemDbContext itemDbContext)
        {
            this.ItemDbContext = itemDbContext;
        }

        public void Delete(Item item)
        {
            ItemDbContext.Entry(item).State = EntityState.Deleted;
            ItemDbContext.SaveChanges();
        }

        public List<Item> FindByDate(DateTime date)
        {
            return ItemDbContext.Items.Where(i => i.Date >= date).OrderBy(i => i.Date).ToList();
        }

        public void Save(Item item)
        {
            ItemDbContext.Entry(item).State = EntityState.Added;
            ItemDbContext.SaveChanges();
        }

        public void Update(Item item)
        {
            ItemDbContext.Entry(item).State = EntityState.Modified;
            ItemDbContext.SaveChanges();
        }
    }
}
