using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using myApp;
using System.Text.RegularExpressions;
using System.Text;

namespace myAppTests
{
    [TestClass]
    public class ConfigTests
    {
        [TestMethod]
        public void Config_ParseConfigStream_CorrectConfigSet()
        {
            // Arrange
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("myAppTests.config.json");

            // Act
            Config config = Config.Parse("config.json");

            // Assert
            Assert.AreEqual("A Path", config.Path);
            Assert.AreEqual("*", config.Filter);
            Assert.AreEqual("", config.Options);
        }
    }
}
