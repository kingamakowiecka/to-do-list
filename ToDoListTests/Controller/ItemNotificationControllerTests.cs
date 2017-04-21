using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller.Tests
{
    [TestClass()]
    public class ItemNotificationControllerTests
    {
        private static DateTime NOW = DateTime.Now;

        private Mock<IItemNotificationRepository> mockItemNotificationRepository;
        private ItemNotificationController itemNotificationController;

        [TestInitialize]
        public void SetUp()
        {
            mockItemNotificationRepository = new Mock<IItemNotificationRepository>();
            itemNotificationController = new ItemNotificationController(mockItemNotificationRepository.Object);
        }

        [TestMethod()]
        public void ShouldReturnItemNotificationByItemId()
        {
            // arrange
            long itemId = 1;
            ItemNotification expectedItemNotification = new ItemNotification();
            mockItemNotificationRepository.Setup(c => c.FindByItemId(itemId)).Returns(expectedItemNotification);

            // act
            ItemNotification returnedItemNotification = itemNotificationController.GetItemNotificationByItemId(itemId);

            // assert
            Assert.AreEqual(expectedItemNotification, returnedItemNotification);
        }

        [TestMethod()]
        public void ShouldCallSaveOnItemNotificationRepositoryForNewItemNotification()
        {
            // arrange
            ItemNotification itemNotification = new ItemNotification();

            // act
            itemNotificationController.SaveItemNotification(itemNotification);

            // assert
            mockItemNotificationRepository.Verify(x => x.Save(itemNotification), Times.Once);
        }

        [TestMethod()]
        public void ShouldCallDeleteOnItemNotificationRepository()
        {
            // arrange
            ItemNotification itemNotification = new ItemNotification();

            // act
            itemNotificationController.DeleteItemNotification(itemNotification);

            // assert
            mockItemNotificationRepository.Verify(x => x.Delete(itemNotification), Times.Once);
        }
    }
}