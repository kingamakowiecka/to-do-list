using System.Collections.Generic;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller
{
    public class ItemController
    {
        private ItemRepository itemRepository;

        public ItemController (ItemRepository itemRepository)
        {
           this.itemRepository = itemRepository;
        }

        public List<Item> getItems()
        {
            return itemRepository.FindAll();
        }
    }
}
