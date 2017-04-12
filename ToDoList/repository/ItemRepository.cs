using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public interface ItemRepository
    {
        List<Item> FindAll();
    }
}
