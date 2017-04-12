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
        private Mock<ItemRepository> mockItemRepository;
        private ItemController itemControllerUnderTest;


        [TestInitialize]
        public void SetUp()
        {
            mockItemRepository = new Mock<ItemRepository>();
            itemControllerUnderTest = new ItemController(mockItemRepository.Object);
        }

        [TestMethod()]
        public void ShouldReturnItemsList()
        {
            //Arrange
            List<Item> expectedItems = new List<Item>();

            mockItemRepository.Setup(m => m.FindAll()).Returns(() => expectedItems);

            //Act
            List<Item> returnedItems = itemControllerUnderTest.getItems();

            //Assert
            Assert.AreEqual(expectedItems, returnedItems);
        }
    }
}