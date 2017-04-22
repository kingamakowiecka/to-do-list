using System;
using ToDoList.Entity;

namespace ToDoListTests.Repository
{
    class RepositoryTestsConstants
    {
        public static DateTime TODAY = DateTime.Now;
        public static DateTime TOMMOROW = TODAY.AddDays(1);
        public static DateTime YESTERDAY = TODAY.AddDays(-1);
        public static Item FIRST_DB_ITEM = new Item { Id = 1, Description = "Descritpion1", Name = "Name1", Date = TODAY };
        public static Item SECOND_DB_ITEM = new Item { Id = 2, Description = "Descritpion2", Name = "Name2", Date = TOMMOROW };
        public static Item THIRD_DB_ITEM = new Item { Id = 3, Description = "Descritpion3", Name = "Name3", Date = TOMMOROW };
        public static Item FOURTH_DB_ITEM = new Item { Id = 4, Description = "Descritpion4", Name = "Name4", Date = YESTERDAY };
        public static ItemNotification FITST_ITEM_NOTIFICATION = new ItemNotification()
        {
            Item = FIRST_DB_ITEM,
            ItemId = FIRST_DB_ITEM.Id,
            NotifiactionDate = TODAY,
            Notified = false
        };
        public static ItemNotification SECOND_ITEM_NOTIFICATION = new ItemNotification()
        {
            Item = SECOND_DB_ITEM,
            ItemId = SECOND_DB_ITEM.Id,
            NotifiactionDate = TOMMOROW,
            Notified = false
        };

        public static ItemNotification THIRD_ITEM_NOTIFICATION = new ItemNotification()
        {
            Item = THIRD_DB_ITEM,
            ItemId = THIRD_DB_ITEM.Id,
            NotifiactionDate = TOMMOROW,
            Notified = false
        };

        public static ItemNotification FOURTH_ITEM_NOTIFICATION = new ItemNotification()
        {
            Item = FOURTH_DB_ITEM,
            ItemId = FOURTH_DB_ITEM.Id,
            NotifiactionDate = TOMMOROW,
            Notified = true
        };
    }
}
