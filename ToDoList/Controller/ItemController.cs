using System;
using System.Collections.Generic;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller
{
    public class ItemController
    {
        private IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void DeleteItem(Item item)
        {
            itemRepository.Delete(item);
        }

        public void SaveItem(Item item)
        {
            if (item.Id == 0)
            {
                itemRepository.Save(item);
            }
            else
            {
                itemRepository.Update(item);
            }
        }

        public List<Item> GetItemsByDate(DateTime date)
        {
            return itemRepository.FindByDate(date);
        }
    }
}
