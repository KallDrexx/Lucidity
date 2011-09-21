using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Parsers.Options;

namespace Lucidity.Tests.Parsers
{
    public class TestParserOptions : ParserOptionsBase
    {
        public string MyString { get; set; }
        public bool MyBool { get; set; }
    }

    [TestClass]
    public class ParserOptionsBaseTests
    {
        [TestMethod]
        public void Can_Get_Parser_Options_Properties_List()
        {
            // Setup
            var options = new TestParserOptions { MyBool = true, MyString = "blah" };

            // Act
            IList<ParserOption> results = options.GetOptions();

            // Verify
            Assert.IsNotNull(results, "Options list was null");
            Assert.AreEqual(2, results.Count, "Options list had an incorrect number of elements");

            Assert.AreEqual("MyString", results[0].Name, "First option's name was incorrect");
            Assert.AreEqual(typeof(string), results[0].PropertyType, "First option's type was incorrect");
            Assert.AreEqual("blah", results[0].CurrentValue, "First option's current value was incorrect");

            Assert.AreEqual("MyBool", results[1].Name, "Second option's name was incorrect");
            Assert.AreEqual(typeof(bool), results[1].PropertyType, "Second option's type was incorrect");
            Assert.AreEqual(true.ToString(), results[1].CurrentValue, "Second option's current value was incorrect");

        }
    }
}
