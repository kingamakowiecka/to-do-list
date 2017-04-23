using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemRepository : IItemRepository
    {
        private ItemsDbContext dbContext;

        public ItemRepository(ItemsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(Item item)
        {
            dbContext.Items.Remove(item);
            dbContext.SaveChanges();
        }

        public List<Item> FindByDate(DateTime date)
        {
            return dbContext.Items.Where(i => i.Date >= date).OrderBy(i => i.Date).ToList();
        }

        public void Save(Item item)
        {
            dbContext.Entry(item).State = EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Update(Item item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
