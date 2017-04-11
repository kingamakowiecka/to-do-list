using System.Collections.Generic;
using ToDoList.entity;
using ToDoList.repository;

namespace ToDoList.controller
{
    class ItemController
    {
        private ItemRepository itemRepository;

        public ItemController (ItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public List<Item> getItems()
        {
            return itemRepository.Items;
        }
    }
}
