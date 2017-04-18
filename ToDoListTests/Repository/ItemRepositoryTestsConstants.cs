using System;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoListTests.Repository
{
    class ItemRepositoryTestsConstants
    {
        public static DateTime TODAY = DateTime.Now;
        public static DateTime TOMMOROW = TODAY.AddDays(1);
        public static DateTime YESTERDAY = TODAY.AddDays(-1);
        public static Item FIRST_DB_ITEM = new Item { Id = 1, Description = "Descritpion1", Name = "Name1", Date = TODAY };
        public static Item SECOND_DB_ITEM = new Item { Id = 2, Description = "Descritpion2", Name = "Name2", Date = TOMMOROW };
        public static Item THIRD_DB_ITEM = new Item { Id = 3, Description = "Descritpion3", Name = "Name3", Date = TOMMOROW };
    }
}
