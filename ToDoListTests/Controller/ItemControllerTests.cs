using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller.Tests
{
    [TestClass()]
    public class ItemControllerTests
    {
        private Mock<IItemRepository> mockItemRepository;
        private ItemController itemController;

        [TestInitialize]
        public void SetUp()
        {
            mockItemRepository = new Mock<IItemRepository>();
            itemController = new ItemController(mockItemRepository.Object);
        }

        [TestMethod()]
        public void ShouldReturnItemsList()
        {
            // arrange
            List<Item> expectedItems = new List<Item>();

            mockItemRepository.Setup(m => m.FindAll()).Returns(() => expectedItems);

            // act
            List<Item> returnedItems = itemController.GetItems();

            // assert
            Assert.AreEqual(expectedItems, returnedItems);
        }

        [TestMethod()]
        public void ShouldSaveNewItemInRepository()
        {
            // arrange
            Item item = new Item();

            // act
            itemController.AddItem(item);

            // assert
            mockItemRepository.Verify(mock => mock.Save(item), Times.Once());
        }
    }
}