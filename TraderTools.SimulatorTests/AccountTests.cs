using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraderTools.Simulator;

namespace TraderTools.SimulatorTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructAccountNegativeBalance()
        {
            var account = new Account(-1024M);
        }

        [TestMethod]
        public void DepositToBalanceValid()
        {
            var account = new Account(1024M);
            account.Deposit(128M);
            Assert.AreEqual(1152M, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepositToBalanceNegative()
        {
            var account = new Account(1024M);
            account.Deposit(-256M);
        }

        [TestMethod]
        public void WithdrawFromBalanceValid()
        {
            var account = new Account(1024M);
            account.Withdraw(128M);
            Assert.AreEqual(896M, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WithdrawFromBalanceNegative()
        {
            var account = new Account(1024M);
            account.Withdraw(-256M);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WithdrawFromBalanceGreaterThanBalance()
        {
            var account = new Account(1024M);
            account.Withdraw(2048M);
        }
    }
}
