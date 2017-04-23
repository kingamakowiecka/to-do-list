using System;
using ToDoList.Entity;

namespace ToDoListTests.Repository
{
    public class BaseRepositoryTests
    {
        public static DateTime TODAY = DateTime.Now;
        public static DateTime TOMMOROW = TODAY.AddDays(1);
        public static DateTime YESTERDAY = TODAY.AddDays(-1);

        public Item PrepareItem(String name, String description, DateTime date, Boolean finished)
        {
            return new Item
            {
                Name = name,
                Description = description,
                Date = date,
                Finished = finished
            };
        }

        public ItemNotification PrepareItemNotification(Item item, DateTime notificationDate, Boolean notified)
        {
            return new ItemNotification()
            {
                Item = item,
                ItemId = item.Id,
                NotifiactionDate = notificationDate,
                Notified = notified
            };
        }
    }
}
