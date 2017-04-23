using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Entity;
using Effort;
using ToDoListTests.Repository;
using System.Collections.Generic;
using System;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class ItemNotificationRepositoryIntegrationTests : BaseRepositoryTests
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
            Item item = PrepareItem("name", "descritpion", TODAY, false);
            ItemNotification notification = PrepareItemNotification(item, TODAY, false);

            dbContext.Items.Add(item);
            dbContext.ItemNotifications.Add(notification);
            dbContext.SaveChanges();

            // act
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(item.Id);

            // assert
            Assert.AreEqual(notification, returnedItemNotification);
        }

        [TestMethod()]
        public void ShouldSaveNewItemNotification()
        {
            // arrange
            Item item = PrepareItem("name", "descritpion", TODAY, false);
            ItemNotification notification = PrepareItemNotification(item, TODAY, false);

            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            // act
            itemNotificationRepository.Save(notification);

            // assert
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(item.Id);
            Assert.AreEqual(notification, returnedItemNotification);
        }

        [TestMethod()]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ShouldThrowEntityValidationExceptionWhenItemNotificationDateIsNull()
        {
            // arrange
            Item item = new Item();
            dbContext.Items.Add(item);

            ItemNotification invalidNotification = new ItemNotification
            {
                Item = item,
                ItemId = item.Id,
                Notified = false
            };

            // act
            itemNotificationRepository.Save(invalidNotification);
        }

        [TestMethod()]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ShouldThrowEntityValidationExceptionWhenItemIsNull()
        {
            // arrange
            Item item = new Item();
            dbContext.Items.Add(item);

            ItemNotification invalidNotification = new ItemNotification
            {
                ItemId = item.Id,
                Notified = false,
                NotifiactionDate = DateTime.Now
            };

            // act
            itemNotificationRepository.Save(invalidNotification);
        }

        [TestMethod()]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ShouldThrowEntityValidationExceptionWhenItemIdIsNull()
        {
            // arrange
            Item item = new Item();
            dbContext.Items.Add(item);

            ItemNotification invalidNotification = new ItemNotification
            {
                Item = item,
                Notified = false,
                NotifiactionDate = DateTime.Now
            };

            // act
            itemNotificationRepository.Save(invalidNotification);
        }

        [TestMethod()]
        [ExpectedException(typeof(DbUpdateException))]
        public void ShouldThrowDbUpdateExceptionWhenSameNotificationWillBeSavedTwoTimes()
        {
            // arrange
            Item item = new Item
            {
                Name = "name",
                Description = "descritpion",
                Date = DateTime.Now
            };
            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            ItemNotification invalidNotification = new ItemNotification
            {
                Item = item,
                ItemId = item.Id,
                Notified = false,
                NotifiactionDate = DateTime.Now
            };

            // act
            itemNotificationRepository.Save(invalidNotification);
            itemNotificationRepository.Save(invalidNotification);
        }

        [TestMethod()]
        public void ShoulDeleteItemNotification()
        {
            // arrange
            Item item = PrepareItem("name", "descritpion", TODAY, false);
            ItemNotification notification = PrepareItemNotification(item, TODAY, false);

            dbContext.Items.Add(item);
            dbContext.ItemNotifications.Add(notification);
            dbContext.SaveChanges();

            // act
            itemNotificationRepository.Delete(notification);

            // assert
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(item.Id);
            Assert.IsNull(returnedItemNotification);
        }

        [TestMethod()]
        public void ShoulReturnNotNotifiedItemsNotificaitonsByDateTime()
        {
            // arrange
            Item firstItem = PrepareItem("name1", "descritpion1", TODAY, false);
            ItemNotification firstNotification = PrepareItemNotification(firstItem, TODAY, false);
            Item secondItem = PrepareItem("name2", "descritpion2", TODAY, false);
            ItemNotification secondNotification = PrepareItemNotification(secondItem, TODAY, true);

            dbContext.Items.Add(firstItem);
            dbContext.Items.Add(secondItem);
            dbContext.ItemNotifications.Add(firstNotification);
            dbContext.ItemNotifications.Add(secondNotification);
            dbContext.SaveChanges();

            // act
            List<ItemNotification> returnedNotifications = itemNotificationRepository.FindNotNotifiedByNotificationDate(TODAY);

            // assert
            Assert.AreEqual(1, returnedNotifications.Count);
            CollectionAssert.Contains(returnedNotifications, firstNotification);
        }

        [TestMethod()]
        public void ShoulUpdateItemNotification()
        {
            // arrange
            Item item = PrepareItem("name", "descritpion", TODAY, false);
            ItemNotification notification = PrepareItemNotification(item, TODAY, false);

            dbContext.Items.Add(item);
            dbContext.ItemNotifications.Add(notification);
            dbContext.SaveChanges();

            // act
            notification.Notified = true;
            itemNotificationRepository.Update(notification);

            // assert
            ItemNotification returnedItemNotification = itemNotificationRepository.FindByItemId(item.Id);
            Assert.AreEqual(true, returnedItemNotification.Notified);
        }
    }
}