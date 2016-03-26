using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TraderTools.Simulator;
using System.Collections.Generic;

namespace TraderTools.SimulatorTests
{
    [TestClass]
    public class MarketTests
    {
        [TestMethod]
        [DeploymentItem("constructMarketTest.csv", "testFiles")]
        public void ConstructWithTextReaderValid()
        {
            TextReader reader = File.OpenText(@"testFiles\constructMarketTest.csv");
            Market market = new Market(reader);

            MarketCandle candle = market.History[5];
            Assert.AreEqual(DateTime.Parse("2016.03.01 00:05"), candle.Time);
            Assert.AreEqual(1.088340M, candle.Open);
            Assert.AreEqual(1.088390M, candle.High);
            Assert.AreEqual(1.088330M, candle.Low);
            Assert.AreEqual(1.088370M, candle.Close);
        }

        [TestMethod]
        [DeploymentItem("getDailyCandlesTest.csv", "testFiles")]
        public void GetDailyCandlesValid()
        {
            TextReader reader = File.OpenText(@"testFiles\getDailyCandlesTest.csv");
            Market market = new Market(reader);

            List<MarketCandle> dailyCandles = market.GetDailyCandles();

            Assert.AreEqual(3, dailyCandles.Count);

            Assert.AreEqual(DateTime.Parse("2016.03.01 00:00"), dailyCandles[0].Time);
            Assert.AreEqual(DateTime.Parse("2016.03.02 00:00"), dailyCandles[1].Time);
            Assert.AreEqual(DateTime.Parse("2016.03.03 00:00"), dailyCandles[2].Time);

            Assert.AreEqual(1.088160M, dailyCandles[0].Open);
            Assert.AreEqual(1.085810M, dailyCandles[1].Open);
            Assert.AreEqual(1.085880M, dailyCandles[2].Open);

            Assert.AreEqual(1.089360M, dailyCandles[0].High);
            Assert.AreEqual(1.087580M, dailyCandles[1].High);
            Assert.AreEqual(1.097280M, dailyCandles[2].High);

            Assert.AreEqual(1.083410M, dailyCandles[0].Low);
            Assert.AreEqual(1.082540M, dailyCandles[1].Low);
            Assert.AreEqual(1.085350M, dailyCandles[2].Low);

            Assert.AreEqual(1.085790M, dailyCandles[0].Close);
            Assert.AreEqual(1.085860M, dailyCandles[1].Close);
            Assert.AreEqual(1.094620M, dailyCandles[2].Close);
        }

        [TestMethod]
        [DeploymentItem("getMonthlyCandlesTest.csv", "testFiles")]
        public void GetMonthlyCandlesValid()
        {
            TextReader reader = File.OpenText(@"testFiles\getMonthlyCandlesTest.csv");
            Market market = new Market(reader);

            List<MarketCandle> monthlyCandles = market.GetMonthlyCandles();

            Assert.AreEqual(3, monthlyCandles.Count);

            Assert.AreEqual(DateTime.Parse("2015.06.01 00:00"), monthlyCandles[0].Time);
            Assert.AreEqual(DateTime.Parse("2015.07.01 00:00"), monthlyCandles[1].Time);
            Assert.AreEqual(DateTime.Parse("2015.08.02 17:00"), monthlyCandles[2].Time);

            //Assert.AreEqual(1.088160M, monthlyCandles[0].Open);
            //Assert.AreEqual(1.085810M, monthlyCandles[1].Open);
            //Assert.AreEqual(1.085880M, monthlyCandles[2].Open);

            //Assert.AreEqual(1.089360M, monthlyCandles[0].High);
            //Assert.AreEqual(1.087580M, monthlyCandles[1].High);
            //Assert.AreEqual(1.097280M, monthlyCandles[2].High);

            //Assert.AreEqual(1.083410M, monthlyCandles[0].Low);
            //Assert.AreEqual(1.082540M, monthlyCandles[1].Low);
            //Assert.AreEqual(1.085350M, monthlyCandles[2].Low);

            //Assert.AreEqual(1.085790M, monthlyCandles[0].Close);
            //Assert.AreEqual(1.085860M, monthlyCandles[1].Close);
            //Assert.AreEqual(1.094620M, monthlyCandles[2].Close);
        }
    }
}