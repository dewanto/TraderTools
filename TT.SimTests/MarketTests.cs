using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TraderTools;

namespace TT.SimTests
{
    [TestClass]
    public class MarketTests
    {
        [TestMethod]
        [DeploymentItem("historyTest.csv", "testFiles")]
        public void ConstructWithTextReaderValid()
        {
            TextReader reader = File.OpenText(@"testFiles\historyTest.csv");
            Market market = new Market(reader);

            Assert.AreEqual(DateTime.Parse("2016.03.01 00:05"), market.History[5].Time);
            Assert.AreEqual(1.088340M, market.History[5].Open);
            Assert.AreEqual(1.088390M, market.History[5].High);
            Assert.AreEqual(1.088330M, market.History[5].Low);
            Assert.AreEqual(1.088370M, market.History[5].Close);
        }
    }
}
