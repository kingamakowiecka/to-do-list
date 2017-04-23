using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToDoList.Util.Tests
{
    [TestClass()]
    public class DateTimeHelperTests
    {
        [TestMethod()]
        public void ShouldResetSecondsInDateTime()
        {
            // arrange
            DateTime dateTimeWithSeconds = new DateTime(2017, 01, 01, 12, 20, 59);
            DateTime expectedDate = new DateTime(2017, 01, 01, 12, 20, 00);

            // act
            DateTime returnedDate = DateTimeHelper.RemoveSecondsFromDateTime(dateTimeWithSeconds);

            // assert
            Assert.AreEqual(expectedDate, returnedDate);
        }
    }
}