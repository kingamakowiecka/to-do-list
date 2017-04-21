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

        public void Save(ItemNotification notification)
        {
            dbContext.Entry(notification).State = EntityState.Added;
            dbContext.SaveChanges();
        }

        ItemNotification IItemNotificationRepository.FindByItemId(long itemId)
        {
            return dbContext.ItemNotifications.Where(i => i.ItemId == itemId).SingleOrDefault();
        }
    }
}
