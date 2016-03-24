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

            MarketCandle candle = market.History[5];
            Assert.AreEqual(DateTime.Parse("2016.03.01 00:05"), candle.Time);
            Assert.AreEqual(1.088340M, candle.Open);
            Assert.AreEqual(1.088390M, candle.High);
            Assert.AreEqual(1.088330M, candle.Low);
            Assert.AreEqual(1.088370M, candle.Close);
        }
    }
}