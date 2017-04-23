using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Effort;
using ToDoListTests.Repository;
using ToDoList.Entity;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class RepositoryIntegrationTests : BaseRepositoryTests
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
            Item item = PrepareItem("name", "descritpion", TODAY, false);
            ItemNotification notification = PrepareItemNotification(item, TODAY, false);

            dbContext.Items.Add(item);
            dbContext.ItemNotifications.Add(notification);
            dbContext.SaveChanges();

            // act
            itemRepository.Delete(item);

            // assert
            List<Item> items = itemRepository.FindByDate(TODAY);
            ItemNotification returnedNotification = itemNotificationRepository.FindByItemId(item.Id);

            Assert.AreEqual(0, items.Count);
            Assert.IsNull(returnedNotification);
        }
    }
}