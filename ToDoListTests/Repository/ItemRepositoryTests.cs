using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Entity;
using Moq;
using System.Data.Entity;
using ToDoListTests.Repository;

namespace ToDoList.Repository.Tests
{
    [TestClass()]
    public class ItemRepositoryTests
    {
        private Mock<ItemDbContext> mockItemDbContext;
        private Mock<DbSet<Item>> mockDbSet;
        private IItemRepository itemRepository;
        private List<Item> expectedItems;

        [TestInitialize]
        public void SetUp()
        {
            expectedItems = PrepareItems();
            mockItemDbContext = new Mock<ItemDbContext>();
            mockDbSet = CreateDbSetMock(expectedItems.AsQueryable());
            itemRepository = new ItemRepository(mockItemDbContext.Object);
        }

        [TestMethod()]
        public void ShouldSaveNewItemInRepository()
        {
            // arrange
            mockItemDbContext.Setup(x => x.Items).Returns(mockDbSet.Object);
            Item newItem = new Item();

            // act
            itemRepository.Save(newItem);

            // assert
            mockItemDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod()]
        public void ShouldUpdateEditedItemInRepository()
        {
            // arrange
            mockItemDbContext.Setup(x => x.Items).Returns(mockDbSet.Object);
            Item item = new Item();

            // act
            item.Description = "AnyDesc";
            itemRepository.Update(item);

            // assert
            mockItemDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod()]
        public void ShouldReturnItemsListByDate()
        {
            // arrange
            mockItemDbContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            // act
            List<Item> returnedItems = itemRepository.FindByDate(ItemRepositoryTestsConstants.TOMMOROW);

            // assert
            Assert.AreEqual(2, returnedItems.Count);
            CollectionAssert.Contains(returnedItems, ItemRepositoryTestsConstants.SECOND_DB_ITEM);
            CollectionAssert.Contains(returnedItems, ItemRepositoryTestsConstants.THIRD_DB_ITEM);
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
                  ItemRepositoryTestsConstants.FIRST_DB_ITEM,
                  ItemRepositoryTestsConstants.SECOND_DB_ITEM,
                  ItemRepositoryTestsConstants.THIRD_DB_ITEM
              };
        }
    }
}