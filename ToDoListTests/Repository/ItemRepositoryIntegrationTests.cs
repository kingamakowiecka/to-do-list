using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Entity;
using Effort;
using ToDoListTests.Repository;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class ItemRepositoryIntegrtionTests
    {
        private ItemsDbContext dbContext;
        private IItemRepository itemRepository;

        [TestInitialize]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreateTransient();
            dbContext = new ItemsDbContext(connection);
            itemRepository = new ItemRepository(dbContext);
        }

        [TestMethod()]
        public void ShouldReturnItemsListByDate()
        {
            // arrange
            dbContext.Items.Add(RepositoryTestsConstants.FIRST_DB_ITEM);
            dbContext.Items.Add(RepositoryTestsConstants.SECOND_DB_ITEM);
            dbContext.Items.Add(RepositoryTestsConstants.THIRD_DB_ITEM);
            dbContext.SaveChanges();

            // act
            List<Item> returnedItems = itemRepository.FindByDate(RepositoryTestsConstants.TOMMOROW);

            // assert
            Assert.AreEqual(2, returnedItems.Count);
            CollectionAssert.Contains(returnedItems, RepositoryTestsConstants.SECOND_DB_ITEM);
            CollectionAssert.Contains(returnedItems, RepositoryTestsConstants.THIRD_DB_ITEM);
        }

        [TestMethod()]
        public void ShouldSaveNewItem()
        {
            // arrange

            // act
            itemRepository.Save(RepositoryTestsConstants.FIRST_DB_ITEM);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(RepositoryTestsConstants.TODAY);
            Assert.AreEqual(1, returnedItems.Count);
            Assert.AreEqual(returnedItems[0].Date, RepositoryTestsConstants.FIRST_DB_ITEM.Date);
            Assert.AreEqual(returnedItems[0].Description, RepositoryTestsConstants.FIRST_DB_ITEM.Description);
            Assert.AreEqual(returnedItems[0].Name, RepositoryTestsConstants.FIRST_DB_ITEM.Name);
            Assert.AreEqual(returnedItems[0].Id, RepositoryTestsConstants.FIRST_DB_ITEM.Id);
        }

        [TestMethod()]
        public void ShouldUpdateItem()
        {
            // arrange
            Item item = new Item { Id = 4, Description = "Item for update", Name = "Update test", Date = RepositoryTestsConstants.TODAY };
            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            // act
            item.Date = RepositoryTestsConstants.YESTERDAY;
            itemRepository.Update(item);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(RepositoryTestsConstants.YESTERDAY);
            Assert.AreEqual(1, returnedItems.Count);
            Assert.AreEqual(returnedItems[0].Date, RepositoryTestsConstants.YESTERDAY);
            Assert.AreEqual(returnedItems[0].Description, item.Description);
            Assert.AreEqual(returnedItems[0].Name, item.Name);
            Assert.AreEqual(returnedItems[0].Id, item.Id);
        }

        [TestMethod()]
        public void ShouldDeleteItemFromDb()
        {
            // arrange
            dbContext.Items.Add(RepositoryTestsConstants.SECOND_DB_ITEM);
            dbContext.Items.Add(RepositoryTestsConstants.THIRD_DB_ITEM);
            dbContext.SaveChanges();

            // act
            itemRepository.Delete(RepositoryTestsConstants.SECOND_DB_ITEM);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(RepositoryTestsConstants.TOMMOROW);
            Assert.AreEqual(1, returnedItems.Count);
            CollectionAssert.DoesNotContain(returnedItems, RepositoryTestsConstants.SECOND_DB_ITEM);
            CollectionAssert.Contains(returnedItems, RepositoryTestsConstants.THIRD_DB_ITEM);
        }
    }
}