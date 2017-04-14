using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class ItemRepositoryTests
    {
        [TestMethod()]
        public void shouldReturnFakeItemsList()
        {
            // arange
            ItemRepository itemRepository = new ItemRepository();

            // act
            List<Item> items = itemRepository.FindAll();

            // assert
            Assert.AreEqual(items.Count, 10);
        }
    }
}