using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDTest1.Task.Task_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace TDDTest1.Task.Task_5.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        private BankAccount _account;
        [TestInitialize]
        public void Initialize()
        {
            _account = new BankAccount(100);
        }

        [TestMethod()]
        public void DepositTest()
        {// Arrange
            decimal amount = 50;
            // Act
            _account.Deposit(amount);
            // Assert
            Assert.AreEqual(150, _account.Balance);

        }

        [TestMethod()]
        public void WithdrawTest()
        {//Arrange
            decimal amount = 50;
            //Act
            _account.Withdraw(amount);
            //Assert
            Assert.AreEqual(50, _account.Balance);
        }

        [TestMethod]
        public void Withdraw_ThrowsException_WhenOverdrawn()
        {
            // Arrange
            decimal withdrawAmount = 200;

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => _account.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Deposit_ThrowsException_ForNegativeAmount()
        {
            // Arrange
            decimal depositAmount = -10;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _account.Deposit(depositAmount));
        }

        [TestMethod]
        public void Withdraw_ThrowsException_ForNegativeAmount()
        {
            // Arrange
            decimal withdrawAmount = -10;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _account.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Withdraw_ThrowsException_ForZeroAmount()
        {
            // Arrange
            decimal withdrawAmount = 0;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _account.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Deposit_ThrowsException_ForZeroAmount()
        {
            // Arrange
            decimal depositAmount = 0;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _account.Deposit(depositAmount));
        }

        [TestMethod]
        public void Account_ThrowsException_WhenInitializedWithNegativeBalance()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(-50));
        }
    }
}