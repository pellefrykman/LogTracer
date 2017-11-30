using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using myApp;

namespace myAppTests
{
    [TestClass]
    public class UnitTest1
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
        public void TestCleanup() {
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("myAppTests.config.json");
            Config config = Config.Parse("config.json");
            Assert.AreEqual("A Path", config.Path);
            Assert.AreEqual("*", config.Filter);
            Assert.AreEqual("", config.Options);
        }

        [TestMethod]
        public void TestMethod2()
        {

            string filePath = Path.Combine(tempPath, "logfile.txt");

            using (StreamWriter writer = new StreamWriter(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))) {
                using (StreamReader reader = new StreamReader(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite)))
                {

                    LogStreamProducer producer = new LogStreamProducer();
                    producer.StartTestLogEntriesToStream(writer);


                    int i = 0;
                    for (int rounds = 0; rounds < 12; rounds++)
                    {
                        while (!reader.EndOfStream)
                        {
                            string text = reader.ReadLine();
                            i++;
                        }
                        Thread.Sleep(1200);
                    }
                    Assert.AreEqual(5, i);
                }
            }
        }
    }
}
