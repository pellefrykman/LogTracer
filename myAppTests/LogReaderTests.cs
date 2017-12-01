using Microsoft.VisualStudio.TestTools.UnitTesting;
using myApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace myAppTests
{
    [TestClass]
    public class LogReaderTests
    {
        private string tempRootPath;
        private string tempPath;

        [TestInitialize]
        public void TestInitialize()
        {
            tempRootPath = Path.Combine(Path.GetTempPath(), "MyAppTests");
            if (Directory.Exists(tempRootPath))
            {
                string[] subDirs = Directory.GetDirectories(tempRootPath);
                foreach (string subDir in subDirs)
                {
                    Directory.Delete(subDir, true);
                }
            }
            tempPath = Path.Combine(tempRootPath, Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempPath);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
        }

        [TestMethod]
        public void LogReader_ReadFileBeingWrittenToWithMultiLineEntries_CorrectNumberOfEntriesRead()
        {
            // Arrange
            string filePath = Path.Combine(tempPath, "logfile.txt");
            File.Create(filePath).Close();
            int numberOfEntriesExpected;
            int numberOfEntriesRead;

            // Act
            using (StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                LogReader logReader = new LogReader(reader);
                logReader.StartReading();


                using (StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.Read)))
                {
                    LogStreamProducer producer = new LogStreamProducer();
                    numberOfEntriesExpected = producer.ISsLogEntries.Count;
                    producer.StartISsLogEntriesToStream(writer);

                    while (producer.IsWriting())
                    {
                        Thread.Sleep(500);
                    }
                }

                while (logReader.MoreEntriesAvailable())
                {
                    Thread.Sleep(200);
                }

                logReader.StopReading();
                numberOfEntriesRead = logReader.Entries.Count;
            }

            // Assert
            Assert.AreEqual(numberOfEntriesExpected, numberOfEntriesRead);
        }
    }
}
