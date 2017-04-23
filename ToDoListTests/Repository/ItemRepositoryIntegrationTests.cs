using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Entity;
using Effort;
using ToDoListTests.Repository;
using System;
using System.Data.Entity.Validation;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class ItemRepositoryIntegrtionTests : BaseRepositoryTests
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
            Item firstItem = PrepareItem("name1", "descritpion1", TODAY, false);
            Item secondItem = PrepareItem("name2", "descritpion2", TOMMOROW, false);
            Item thirdItem = PrepareItem("name3", "descritpion3", TOMMOROW, false);
            dbContext.Items.Add(firstItem);
            dbContext.Items.Add(secondItem);
            dbContext.Items.Add(thirdItem);
            dbContext.SaveChanges();

            // act
            List<Item> returnedItems = itemRepository.FindByDate(TOMMOROW);

            // assert
            Assert.AreEqual(2, returnedItems.Count);
            CollectionAssert.Contains(returnedItems, secondItem);
            CollectionAssert.Contains(returnedItems, thirdItem);
        }

        [TestMethod()]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ShouldThrowEntityValidationExceptionWhenItemNameIsNull()
        {
            // arrange
            Item item = new Item
            {
                Description = "desc",
                Date = DateTime.Now
            };

            // act
            itemRepository.Save(item);
        }

        [TestMethod()]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ShouldThrowEntityValidationExceptionWhenItemDateIsNull()
        {
            // arrange
            Item item = new Item
            {
                Description = "desc",
                Name = "Name"
            };

            // act
            itemRepository.Save(item);
        }

        [TestMethod()]
        public void ShouldSaveNewItem()
        {
            // arrange
            Item item = PrepareItem("name", "descritpion", TODAY, false);

            // act
            itemRepository.Save(item);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(TODAY);
            Assert.AreEqual(1, returnedItems.Count);
            Assert.AreEqual(returnedItems[0].Date, item.Date);
            Assert.AreEqual(returnedItems[0].Description, item.Description);
            Assert.AreEqual(returnedItems[0].Name, item.Name);
            Assert.AreEqual(returnedItems[0].Id, item.Id);
        }

        [TestMethod()]
        public void ShouldUpdateItem()
        {
            // arrange
            Item item = PrepareItem("Update test", "Item for update", TODAY, false);
            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            // act
            item.Date = YESTERDAY;
            itemRepository.Update(item);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(YESTERDAY);
            Assert.AreEqual(1, returnedItems.Count);
            Assert.AreEqual(returnedItems[0].Date, YESTERDAY);
            Assert.AreEqual(returnedItems[0].Description, item.Description);
            Assert.AreEqual(returnedItems[0].Name, item.Name);
            Assert.AreEqual(returnedItems[0].Id, item.Id);
        }

        [TestMethod()]
        public void ShouldDeleteItemFromDb()
        {
            // arrange
            Item secondItem = PrepareItem("name2", "descritpion2", TOMMOROW, false);
            Item thirdItem = PrepareItem("name3", "descritpion3", TOMMOROW, false);
            dbContext.Items.Add(secondItem);
            dbContext.Items.Add(thirdItem);
            dbContext.SaveChanges();

            // act
            itemRepository.Delete(secondItem);

            // assert
            List<Item> returnedItems = itemRepository.FindByDate(TOMMOROW);
            Assert.AreEqual(1, returnedItems.Count);
            CollectionAssert.DoesNotContain(returnedItems, secondItem);
            CollectionAssert.Contains(returnedItems, thirdItem);
        }
    }
}