using System;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public interface IItemNotificationRepository
    {
        void Delete(ItemNotification notification);
        List<ItemNotification> FindNotNotifiedByNotificationDate(DateTime notifiactionDate);
        ItemNotification FindByItemId(long itemId);
        void Save(ItemNotification notification);
        void Update(ItemNotification notification);
    }
}
