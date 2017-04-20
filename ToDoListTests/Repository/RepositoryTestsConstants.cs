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
        public static ItemNotification FITST_ITEM_NOTIFICATION = new ItemNotification()
        {
            Id = 1,
            Item = FIRST_DB_ITEM,
            ItemId = FIRST_DB_ITEM.Id,
            NotifiactionDate = FIRST_DB_ITEM.Date
        };
        public static ItemNotification SECOND_ITEM_NOTIFICATION = new ItemNotification()
        {
            Id = 1,
            Item = SECOND_DB_ITEM,
            ItemId = SECOND_DB_ITEM.Id,
            NotifiactionDate = SECOND_DB_ITEM.Date
        };
    }
}
