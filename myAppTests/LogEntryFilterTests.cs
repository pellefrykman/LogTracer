using Microsoft.VisualStudio.TestTools.UnitTesting;
using myApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace myAppTests
{
    [TestClass]
    public class LogEntryFilterTests
    {
        [TestMethod]
        public void TestMethod()
        {
            // Arrange
            string pattern = @"from: ";
            List<string> filteredEntries = new List<string>();
            LogEntryFilter filter = new LogEntryFilter(pattern, (message) =>
            {
                filteredEntries.Add(message);
            });

            // Act
            foreach (string entry in TestData.ISsLogEntries)
            {
                filter.process(entry);
            }

            // Assert
            Assert.AreEqual(4, filteredEntries.Count);
        }
    }
}
