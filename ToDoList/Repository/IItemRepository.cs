using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public interface IItemRepository
    {
        List<Item> FindAll();

        void Save(Item item);
    }
}
