﻿using System;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository
{
    public interface IItemRepository
    {
        void Delete(Item item);
        List<Item> FindByDate(DateTime date);
        void Save(Item item);
        void Update(Item item);
    }
}
