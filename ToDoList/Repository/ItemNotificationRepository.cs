using System.Data.Entity;
using System.Linq;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemNotificationRepository : IItemNotificationRepository
    {
        private ItemsDbContext dbContext;

        public ItemNotificationRepository(ItemsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(ItemNotification notification)
        {
            dbContext.ItemNotifications.Remove(notification);
            dbContext.SaveChanges();
        }

        public void Save(ItemNotification notification)
        {
            dbContext.Entry(notification).State = EntityState.Added;
            dbContext.SaveChanges();
        }

        public ItemNotification FindByItemId(long itemId)
        {
            return dbContext.ItemNotifications.Where(i => i.ItemId == itemId).SingleOrDefault();
        }
    }
}
