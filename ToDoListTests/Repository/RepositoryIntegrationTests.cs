using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Effort;
using ToDoListTests.Repository;
using ToDoList.Entity;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class RepositoryIntegrationTests
    {
        private ItemsDbContext dbContext;
        private IItemNotificationRepository itemNotificationRepository;
        private IItemRepository itemRepository;

        [TestInitialize]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreateTransient();
            dbContext = new ItemsDbContext(connection);
            itemNotificationRepository = new ItemNotificationRepository(dbContext);
            itemRepository = new ItemRepository(dbContext);
        }

        [TestMethod()]
        public void ShouldDeleteItemAndItsNotification()
        {
            // arrange
            dbContext.Items.Add(RepositoryTestsConstants.THIRD_DB_ITEM);
            dbContext.ItemNotifications.Add(RepositoryTestsConstants.THIRD_ITEM_NOTIFICATION);
            dbContext.SaveChanges();

            // act
            itemRepository.Delete(RepositoryTestsConstants.THIRD_DB_ITEM);

            // assert
            List<Item> items = itemRepository.FindByDate(RepositoryTestsConstants.YESTERDAY);
            ItemNotification notification = itemNotificationRepository.FindByItemId(RepositoryTestsConstants.THIRD_DB_ITEM.Id);

            Assert.AreEqual(0, items.Count);
            Assert.IsNull(notification);
        }
    }
}