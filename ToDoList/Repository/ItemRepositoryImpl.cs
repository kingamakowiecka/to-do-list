using System;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemRepositoryImpl : ItemRepository
    {
        private List<Item> items = new List<Item>();

        public ItemRepositoryImpl()
        {
            for (int i = 0; i < 10; i++)
            {
                items.Add(PrepareFakeItem(i));
            }
        }

        public List<Item> FindAll()
        {
            return items;
        }

        private Item PrepareFakeItem(int itemNumber)
        {
            Item item = new Item();
            item.Id = itemNumber;
            item.Decription = "description" + itemNumber;
            item.Date = DateTime.Now;
            item.Finished = false;
            item.Name = "name" + itemNumber;

            return item;
        }

    }
}
