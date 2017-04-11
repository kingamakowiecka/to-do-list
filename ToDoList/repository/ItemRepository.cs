using System;
using System.Collections.Generic;
using ToDoList.entity;

namespace ToDoList.repository
{
    public class ItemRepository
    {
        private List<Item> items = new List<Item>();

        public ItemRepository()
        {
            for (int i = 0; i < 10; i++)
            {
                items.Add(PrepareFakeItem(i));
            }
        }

        public List<Item> Items { get => items; set => items = value; }

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
