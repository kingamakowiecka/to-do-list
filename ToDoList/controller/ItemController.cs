using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller
{
    public class ItemController
    {
        private ItemRepository itemRepository;

        public ItemController(ItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void AddItem(Item item)
        {
            itemRepository.Items.Add(item);
            itemRepository.SaveChanges();
        }

        public List<Item> GetItemsByDate(DateTime date)
        {
            return itemRepository.Items.Where(i => i.Date >= date).OrderBy(i => i.Date).ToList();
        }
    }
}
