using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucidity.Engine.Exceptions;
using Lucidity.Engine.Parsers;
using Lucidity.Engine.Data;
using Lucidity.Engine.Options;
using Lucidity.StandardTypes.Parsers;
using Lucidity.StandardTypes.Parsers.Options;

namespace Lucidity.Tests.Parsers
{
    [TestClass]
    [DeploymentItem(@"TestData\pipeLogTest.txt")]
    [DeploymentItem(@"TestData\PipeWithDate.txt")]
    public class PipeDelimitedLogParserTests : ParserBaseTests
    {
        [TestInitialize]
        public void Setup()
        {
            _parser = new PipeDelimitedLogParser();
            _expectedOptionsType = typeof(PipeDelimitedParserOptions);
            _generalLogSource = "pipeLogTest.txt";
            _dateLogSource = "PipeWithDate.txt";
        }
    }
}