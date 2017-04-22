using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Entity;
using Effort;
using ToDoListTests.Repository;
using System.Collections.Generic;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class ItemNotificationRepositoryIntegrationTests
    {
        private ItemsDbContext dbContext;
        private IItemNotificationRepository itemNotificationRepository;

        [TestInitialize]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreateTransient();
            dbContext = new ItemsDbContext(connection);
            itemNotificationRepository = new ItemNotificationRepository(dbContext);
        }

        [TestMethod()]
        public void ShouldReturnItemNotificationByItemId()
        {
            // arrange
            dbContext.Items.Add(RepositoryTestsConstants.FIRST_DB_ITEM);
            dbContext.ItemNotifications.Add(RepositoryTestsConstants.FITST_ITEM_NOTIFICATION);
            dbContext.SaveChanges();

            // act
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(RepositoryTestsConstants.FIRST_DB_ITEM.Id);

            // assert
            Assert.AreEqual(RepositoryTestsConstants.FITST_ITEM_NOTIFICATION, returnedItemNotification);
        }

        [TestMethod()]
        public void ShouldSaveNewItemNotification()
        {
            // arrange

            // act
            itemNotificationRepository.Save(RepositoryTestsConstants.SECOND_ITEM_NOTIFICATION);

            // assert
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(RepositoryTestsConstants.SECOND_DB_ITEM.Id);
            Assert.AreEqual(RepositoryTestsConstants.SECOND_ITEM_NOTIFICATION, returnedItemNotification);
        }

        [TestMethod()]
        public void ShoulDeleteItemNotification()
        {
            // arrange
            dbContext.Items.Add(RepositoryTestsConstants.FIRST_DB_ITEM);
            dbContext.ItemNotifications.Add(RepositoryTestsConstants.FITST_ITEM_NOTIFICATION);
            dbContext.SaveChanges();

            // act
            itemNotificationRepository.Delete(RepositoryTestsConstants.FITST_ITEM_NOTIFICATION);

            // assert
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(RepositoryTestsConstants.SECOND_DB_ITEM.Id);
            Assert.IsNull(returnedItemNotification);
        }

        [TestMethod()]
        public void ShoulReturnNotNotifiedItemsNotificaitonsByDateTime()
        {
            // arrange
            dbContext.Items.Add(RepositoryTestsConstants.SECOND_DB_ITEM);
            dbContext.ItemNotifications.Add(RepositoryTestsConstants.SECOND_ITEM_NOTIFICATION);
            dbContext.Items.Add(RepositoryTestsConstants.FOURTH_DB_ITEM);
            dbContext.ItemNotifications.Add(RepositoryTestsConstants.FOURTH_ITEM_NOTIFICATION);
            dbContext.SaveChanges();

            // act
            List<ItemNotification> returnedNotifications = itemNotificationRepository.FindNotNotifiedByNotificationDate(RepositoryTestsConstants.TOMMOROW);

            // assert
            Assert.AreEqual(1, returnedNotifications.Count);
            CollectionAssert.Contains(returnedNotifications, RepositoryTestsConstants.SECOND_ITEM_NOTIFICATION);
        }

        [TestMethod()]
        public void ShoulUpdateItemNotification()
        {
            // arrange
            dbContext.Items.Add(RepositoryTestsConstants.FOURTH_DB_ITEM);
            dbContext.ItemNotifications.Add(RepositoryTestsConstants.FOURTH_ITEM_NOTIFICATION);
            dbContext.SaveChanges();

            // act
            RepositoryTestsConstants.FOURTH_ITEM_NOTIFICATION.Notified = true;
            itemNotificationRepository.Update(RepositoryTestsConstants.FOURTH_ITEM_NOTIFICATION);

            // assert
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(RepositoryTestsConstants.FOURTH_DB_ITEM.Id);
            Assert.AreEqual(true, returnedItemNotification.Notified);
        }
    }
}