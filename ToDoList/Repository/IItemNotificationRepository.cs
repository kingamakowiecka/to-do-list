using ToDoList.Entity;

namespace ToDoList.Repository
{
    public interface IItemNotificationRepository
    {
        void Delete(ItemNotification notification);
        ItemNotification FindByItemId(long itemId);
        void Save(ItemNotification notification);
    }
}
