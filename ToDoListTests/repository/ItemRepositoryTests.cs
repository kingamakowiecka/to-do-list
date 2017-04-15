using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class ItemRepositoryTests
    {
        private static long NEW_ITEM_ID = 11;
        private static String NEW_ITEM_DESCRIPTION = "new item description";
        private static String NEW_ITEM_NAME = "new item name";
        private static DateTime NEW_ITEM_DATE = DateTime.Now;
        private static Boolean NEW_ITEM_FINISHED = false;

        [TestMethod()]
        public void ShouldReturnFakeItemsList()
        {
            // arange
            ItemRepository itemRepository = new ItemRepository();

            // act
            List<Item> items = itemRepository.FindAll();

            // assert
            Assert.AreEqual(items.Count, 10);
        }

        [TestMethod()]
        public void ShouldSaveNewItemOnList()
        {
            // arrange
            ItemRepository itemRepository = new ItemRepository();

            // act
            itemRepository.Save(PrepareNewItem());

            // assert
            List<Item> items = itemRepository.FindAll();
            Assert.AreEqual(items.Count, 11);
            Assert.AreEqual(items[10].Id, NEW_ITEM_ID);
            Assert.AreEqual(items[10].Decription, NEW_ITEM_DESCRIPTION);
            Assert.AreEqual(items[10].Name, NEW_ITEM_NAME);
            Assert.AreEqual(items[10].Date, NEW_ITEM_DATE);
            Assert.AreEqual(items[10].Finished, NEW_ITEM_FINISHED);
        }

        private static Item PrepareNewItem()
        {
            return new Item()
            {
                Id = NEW_ITEM_ID,
                Decription = NEW_ITEM_DESCRIPTION,
                Date = NEW_ITEM_DATE,
                Finished = NEW_ITEM_FINISHED,
                Name = NEW_ITEM_NAME
            };
        }
    }
}