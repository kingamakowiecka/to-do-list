using System;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> items = new List<Item>();

        public ItemRepository()
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

        public void Save(Item item)
        {
            items.Add(item);
        }

        private Item PrepareFakeItem(int itemNumber)
        {
            Item item = new Item()
            {
                Id = itemNumber,
                Decription = "description" + itemNumber,
                Date = DateTime.Now,
                Finished = false,
                Name = "name" + itemNumber
            };

            return item;
        }

    }
}
