using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller.Tests
{
    [TestClass()]
    public class ItemControllerTests
    {
        private static DateTime NOW = DateTime.Now;

        private Mock<IItemRepository> mockItemRepository;
        private ItemController itemController;
        private List<Item> expectedItems;

        [TestInitialize]
        public void SetUp()
        {
            expectedItems = PrepareItems();
            mockItemRepository = new Mock<IItemRepository>();
            itemController = new ItemController(mockItemRepository.Object);
        }

        [TestMethod()]
        public void ShouldReturnItemsListByDate()
        {
            // arrange
            mockItemRepository.Setup(c => c.FindByDate(NOW)).Returns(expectedItems);

            // act
            List<Item> returnedItems = itemController.GetItemsByDate(NOW);

            // assert
            CollectionAssert.AreEqual(expectedItems, returnedItems);
        }

        [TestMethod()]
        public void ShouldCallSaveOnItemRepositoryForNewItem()
        {
            // arrange
            Item newItem = new Item();

            // act
            itemController.SaveItem(newItem);

            // assert
            mockItemRepository.Verify(x => x.Save(newItem), Times.Once);
        }

        [TestMethod()]
        public void ShouldCallUpdateOnItemRepositoryForNewItem()
        {
            // arrange
            Item newItem = new Item { Id = 1 };

            // act
            itemController.SaveItem(newItem);

            // assert
            mockItemRepository.Verify(x => x.Update(newItem), Times.Once);
        }

        [TestMethod()]
        public void ShouldCallDeleteOnItemRepositoryForNewItem()
        {
            // arrange
            Item itemToDelete = new Item();

            // act
            itemController.DeleteItem(itemToDelete);

            // assert
            mockItemRepository.Verify(x => x.Delete(itemToDelete), Times.Once);
        }


        private List<Item> PrepareItems()
        {
            return new List<Item>
              {
                  new Item()
              };
        }
    }
}