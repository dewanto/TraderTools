using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TraderTools.Simulator;

namespace TraderTools.SimulatorTests
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

            MarketOHLC ohlc = market.History[5];
            Assert.AreEqual(DateTime.Parse("2016.03.01 00:05"), ohlc.Time);
            Assert.AreEqual(1.088340M, ohlc.Open);
            Assert.AreEqual(1.088390M, ohlc.High);
            Assert.AreEqual(1.088330M, ohlc.Low);
            Assert.AreEqual(1.088370M, ohlc.Close);
        }
    }
}