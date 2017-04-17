using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Controller.Tests
{
    [TestClass()]
    public class ItemControllerTests
    {
        private static DateTime TODAY = DateTime.Now;
        private static DateTime TOMMOROW = TODAY.AddDays(1);
        private static Item FIRST_DB_ITEM = new Item { Id = 1, Description = "Descritpion1", Name = "Name1", Date = TODAY };
        private static Item SECOND_DB_ITEM = new Item { Id = 2, Description = "Descritpion2", Name = "Name2", Date = TOMMOROW };
        private static Item THIRD_DB_ITEM = new Item { Id = 3, Description = "Descritpion3", Name = "Name3", Date = TOMMOROW };

        private Mock<ItemRepository> mockItemRepository;
        private Mock<DbSet<Item>> mockDbSet;
        private ItemController itemController;
        private List<Item> expectedItems;

        [TestInitialize]
        public void SetUp()
        {
            expectedItems = PrepareItems();
            mockItemRepository = new Mock<ItemRepository>();
            mockDbSet = CreateDbSetMock(expectedItems.AsQueryable());
            itemController = new ItemController(mockItemRepository.Object);
        }
        
        [TestMethod()]
        public void ShouldReturnItemsListByDate()
        {
            // arrange
            mockItemRepository.Setup(c => c.Items).Returns(mockDbSet.Object);

            // act
            List<Item> returnedItems = itemController.GetItemsByDate(TOMMOROW);

            // assert
            Assert.AreEqual(2, returnedItems.Count);
            CollectionAssert.Contains(returnedItems, SECOND_DB_ITEM);
            CollectionAssert.Contains(returnedItems, THIRD_DB_ITEM);
        }

        [TestMethod()]
        public void ShouldSaveNewItemInRepository()
        {
            // arrange
            mockItemRepository.Setup(x => x.Items).Returns(mockDbSet.Object);
            Item newItem = new Item();

            // act
            itemController.AddItem(newItem);

            // assert
            mockDbSet.Verify(x => x.Add(newItem), Times.Once);
            mockItemRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        private Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }

        private List<Item> PrepareItems()
        {
            return new List<Item>
            {
                FIRST_DB_ITEM,
                SECOND_DB_ITEM,
                THIRD_DB_ITEM
            };
        }
    }
}