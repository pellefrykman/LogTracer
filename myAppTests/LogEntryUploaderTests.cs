using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using myApp;

namespace myAppTests
{
    [TestClass]
    public class LogEntryUploaderTests
    {
        [TestMethod]
        public void LogEntryUploader_Upload_Ok()
        {
            // Arrange
            LogEntryInformation logEntryInfo = new LogEntryInformation()
            {
                TimeStamp = DateTime.Now,
                EventType = "Testitem",
                EventKey = "Ha, här så...",
            };

            // Act
            LogEntryUploader.UploadToCosmos(logEntryInfo);

            // Assert
        }
    }
}
