using ToDoList.Entity;

namespace ToDoList.Repository
{
    public interface IItemNotificationRepository
    {
        ItemNotification FindByItemId(long itemId);
        void Save(ItemNotification notification);
    }
}
