using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller
{
    public class ItemNotificationController
    {
        private IItemNotificationRepository itemNotificationRepository;

        public ItemNotificationController(IItemNotificationRepository itemNotificationRepository)
        {
            this.itemNotificationRepository = itemNotificationRepository;
        }

        public void SaveItemNotification(ItemNotification itemNotification)
        {
            itemNotificationRepository.Save(itemNotification);
        }

        public ItemNotification GetItemNotificationByItemId(long itemId)
        {
            return itemNotificationRepository.FindByItemId(itemId);
        }

        public void DeleteItemNotification(ItemNotification itemNotification)
        {
            itemNotificationRepository.Delete(itemNotification);
        }
    }
}
