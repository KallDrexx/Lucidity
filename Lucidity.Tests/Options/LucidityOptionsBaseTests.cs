using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Options;
using Lucidity.Engine.Exceptions;

namespace Lucidity.Tests.Options
{
    public class TestParserOptions : LucidityOptionsBase
    {
        public string MyString { get; set; }
        public bool MyBool { get; set; }
        public long UnsupportedType { get; set; }
    }

    [TestClass]
    public class LucidityOptionsBaseTests
    {
        [TestMethod]
        public void Can_Get_Parser_Options()
        {
            // Setup
            var options = new TestParserOptions { MyBool = true, MyString = "blah" };

            // Act
            IList<LucidityOption> results = options.GetOptions();

            // Verify
            Assert.IsNotNull(results, "Options list was null");
            Assert.AreEqual(2, results.Count, "Options list had an incorrect number of elements");

            Assert.AreEqual("MyString", results[0].Name, "First option's name was incorrect");
            Assert.AreEqual(SupportedOptionTypes.String, results[0].OptionType, "First option's type was incorrect");
            Assert.AreEqual("blah", results[0].Value, "First option's current value was incorrect");

            Assert.AreEqual("MyBool", results[1].Name, "Second option's name was incorrect");
            Assert.AreEqual(SupportedOptionTypes.Bool, results[1].OptionType, "Second option's type was incorrect");
            Assert.AreEqual(true, results[1].Value, "Second option's current value was incorrect");

        }

        [TestMethod]
        public void Can_Set_Parser_Options()
        {
            // Setup
            var options = new TestParserOptions();
            var opts = options.GetOptions();
            opts.Where(x => x.Name == "MyString").First().Value = "test123";
            opts.Where(x => x.Name == "MyBool").First().Value = true;

            // Act
            options.UpdateOptionValues();

            // Verify
            Assert.AreEqual("test123", options.MyString, "Options.MyString had an incorrect value");
            Assert.AreEqual(true, options.MyBool, "Option.MyBool had an incorrect value");
        }

        [TestMethod]
        [ExpectedException(typeof(OptionTypeMismatchException))]
        public void InvalidOperationException_Thrown_When_Value_Type_Doesnt_Match_Property_Type()
        {
            // Setup
            var options = new TestParserOptions();
            var opt = options.GetOptions();
            opt.Where(x => x.Name == "MyString").First().Value = true;

            // Act
            options.UpdateOptionValues();
        }
    }
}
