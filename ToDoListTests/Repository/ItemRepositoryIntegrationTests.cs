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
        private ItemDbContext itemDbContext;
        private IItemRepository itemRepository;

        [TestInitialize]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreateTransient();
            itemDbContext = new ItemDbContext(connection);
            itemRepository = new ItemRepository(itemDbContext);
        }

        [TestMethod()]
        public void ShouldReturnItemsListByDate()
        {
            // arrange
            itemDbContext.Items.Add(ItemRepositoryTestsConstants.FIRST_DB_ITEM);
            itemDbContext.Items.Add(ItemRepositoryTestsConstants.SECOND_DB_ITEM);
            itemDbContext.Items.Add(ItemRepositoryTestsConstants.THIRD_DB_ITEM);
            itemDbContext.SaveChanges();

            // act
            List<Item> returnedItems = itemRepository.FindByDate(ItemRepositoryTestsConstants.TOMMOROW);

            // assert
            Assert.AreEqual(2, returnedItems.Count);
            CollectionAssert.Contains(returnedItems, ItemRepositoryTestsConstants.SECOND_DB_ITEM);
            CollectionAssert.Contains(returnedItems, ItemRepositoryTestsConstants.THIRD_DB_ITEM);
        }

        [TestMethod()]
        public void ShouldSaveNewItem()
        {
            // arrange

            // act
            itemRepository.Save(ItemRepositoryTestsConstants.FIRST_DB_ITEM);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(ItemRepositoryTestsConstants.TODAY);
            Assert.AreEqual(1, returnedItems.Count);
            Assert.AreEqual(returnedItems[0].Date, ItemRepositoryTestsConstants.FIRST_DB_ITEM.Date);
            Assert.AreEqual(returnedItems[0].Description, ItemRepositoryTestsConstants.FIRST_DB_ITEM.Description);
            Assert.AreEqual(returnedItems[0].Name, ItemRepositoryTestsConstants.FIRST_DB_ITEM.Name);
            Assert.AreEqual(returnedItems[0].Id, ItemRepositoryTestsConstants.FIRST_DB_ITEM.Id);
        }

        [TestMethod()]
        public void ShouldUpdateItem()
        {
            // arrange
            Item item = new Item { Id = 4, Description = "Item for update", Name = "Update test", Date = ItemRepositoryTestsConstants.TODAY };
            itemDbContext.Items.Add(item);
            itemDbContext.SaveChanges();

            // act
            item.Date = ItemRepositoryTestsConstants.YESTERDAY;
            itemRepository.Update(item);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(ItemRepositoryTestsConstants.YESTERDAY);
            Assert.AreEqual(1, returnedItems.Count);
            Assert.AreEqual(returnedItems[0].Date, ItemRepositoryTestsConstants.YESTERDAY);
            Assert.AreEqual(returnedItems[0].Description, item.Description);
            Assert.AreEqual(returnedItems[0].Name, item.Name);
            Assert.AreEqual(returnedItems[0].Id, item.Id);
        }

        [TestMethod()]
        public void ShouldDeleteItemFromDb()
        {
            // arrange
            itemDbContext.Items.Add(ItemRepositoryTestsConstants.SECOND_DB_ITEM);
            itemDbContext.Items.Add(ItemRepositoryTestsConstants.THIRD_DB_ITEM);
            itemDbContext.SaveChanges();

            // act
            itemRepository.Delete(ItemRepositoryTestsConstants.SECOND_DB_ITEM);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(ItemRepositoryTestsConstants.TOMMOROW);
            Assert.AreEqual(1, returnedItems.Count);
            CollectionAssert.DoesNotContain(returnedItems, ItemRepositoryTestsConstants.SECOND_DB_ITEM);
            CollectionAssert.Contains(returnedItems, ItemRepositoryTestsConstants.THIRD_DB_ITEM);
        }
    }
}