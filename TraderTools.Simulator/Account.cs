using System;

namespace TraderTools.Simulator
{
    public class Account
    {
        public decimal Balance { get; private set; }

        public Account(decimal initialBalance)
        {
            if (initialBalance < 0) throw new ArgumentException("Balance cannot be negative");
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Cannot deposit negative amount; use Withdraw() instead");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Cannot withdraw negative amount; use Deposit() instead");
            if (Balance - amount < 0) throw new ArgumentException("Cannot withdraw amount greater than balance");
            Balance -= amount;
        }
    }
}