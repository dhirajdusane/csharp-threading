using System;
using System.Threading;

namespace LocksAndMonitor
{
    internal class Account
    {
        private readonly object withdrawLock = new object();

        Random random = new Random();

        int balance;

        public Account(int initialBalance)
        {
            this.balance = initialBalance;
        }

        int Withdraw(int amount)
        {
            if(balance < 0)
            {
                throw new Exception("Not enough balance.");
            }

            // Equivalent to lock()
            Monitor.Enter(withdrawLock);

            try
            {
                if(balance >= amount)
                {
                    Console.WriteLine("Amount withdrawn: " + amount);

                    balance -= amount;

                    return balance;
                }
            }
            finally
            {
                Monitor.Exit(withdrawLock);
            }

            return 0;
        }

        public void WithdrawRandomly()
        {
            for (int i = 0; i < 100; i++)
            {
                var balance = Withdraw(random.Next(2000, 5000));

                if (balance > 0)
                {
                    Console.WriteLine("Balance left: " + balance);
                }

                Console.WriteLine("Not enough balance");
            }
        }
    }
}
