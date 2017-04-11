using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.entity;

namespace ToDoList.repository.Tests
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
            List<Item> items = itemRepository.Items;

            // assert
            Assert.AreEqual(items.Count, 10);
        }
    }
}