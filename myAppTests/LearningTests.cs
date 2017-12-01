using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace myAppTests
{
    [TestClass]
    public class LearningTests
    {
        [TestMethod]
        public void Learning_RegexpMatch()
        {
            string text = "2017-11-30 06:55:17.322 T5264 w_store_main - I1 identity: SODPRO21";
            Regex regex = new Regex(@"\d{4}-\d{2}-\d{2}", RegexOptions.IgnoreCase);

            Assert.IsTrue(regex.IsMatch(text));
        }

        [TestMethod]
        public void Learning_RegexpCapturing()
        {
            string text = "    to  : E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_7/x0000.dcm";
            string pattern = "to  : (?<value>.*)";
            Regex regex = new Regex(pattern);

            string value = regex.Match(text).Value;
            string capture = regex.Match(text).Groups["value"].Value;

            Assert.AreEqual("to  : E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_7/x0000.dcm", value);
            Assert.AreEqual("E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_7/x0000.dcm", capture);
        }

        [TestMethod]
        public void Learning_StringBuilder()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string expected =
 @"First line.
Second line.";

            stringBuilder.Append("First line.");
            stringBuilder.AppendLine();
            stringBuilder.Append("Second line.");

            string result = stringBuilder.ToString();

            Assert.AreEqual(expected, result, message: result);
        }
    }
}
