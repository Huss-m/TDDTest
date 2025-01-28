using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDTest1.Task.Task_5
{
    public class BankAccount
    {
        private decimal _balance;

        public decimal Balance => _balance; // Läsbart saldo

        public BankAccount(decimal initialBalance = 0)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative.");
            }
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > _balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            _balance -= amount;
        }
    }
}
