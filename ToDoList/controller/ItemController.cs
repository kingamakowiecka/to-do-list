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

        public List<Item> GetItems()
        {
            return itemRepository.Items.ToList();
        }

        public void AddItem(Item item)
        {
            itemRepository.Items.Add(item);
            itemRepository.SaveChanges();
        }
    }
}
