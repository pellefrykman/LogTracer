using Microsoft.VisualStudio.TestTools.UnitTesting;
using myApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace myAppTests
{
    [TestClass]
    public class LogEntryTransformerTests
    {
        [TestMethod]
        public void LogEntryTransformer_Transform_CorrectTransform()
        {
            // Arrange
            string logEntry = @"2017-11-30 06:55:20.082 T1060 wi/copy_file - I1 Moving image
    from: E:\in_dcm/SODPRO21/1.2.752.24.7.112976771.1221110.6730030.0.20171130064411__1209858157.dcm
    to  : E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_7/x0000.dcm";
            LogEntryTransformer transformer = new LogEntryTransformer("NewImageStored", "to  : (?<value>.*)");

            // Act
            LogEntryInformation logEntryInfo = transformer.Transform(logEntry);

            // Assert
            Assert.AreEqual(new DateTime(2017, 11, 30, 6, 55, 20, 82), logEntryInfo.TimeStamp);
            Assert.AreEqual("NewImageStored", logEntryInfo.EventType);
            Assert.AreEqual("E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_7/x0000.dcm", logEntryInfo.EventKey);
        }
    }
}
