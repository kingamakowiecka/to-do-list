using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Entity;
using Effort;
using ToDoListTests.Repository;

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
    }
}