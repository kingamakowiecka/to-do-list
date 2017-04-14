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

        public List<Item> GetItems()
        {
            return itemRepository.FindAll();
        }
    }
}
