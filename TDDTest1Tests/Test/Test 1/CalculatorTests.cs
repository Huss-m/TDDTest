using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDTest1.Task.Task_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TDDTest1.Task.Task_1.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var task = new Calculator();
            int a = 1;
            int b = 2;
            float expected = 3;
            task.Add(a, b);
            // Act
            float actual = task.Add(a, b);
            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SubtractTest()
        {
            //Arrange
            var task = new Calculator();
            int a = 1;
            int b = 2;
            float expected = -1;
            task.Subtract(a, b);
            //Act
            float actual = task.Subtract(a, b);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            // Arrange
            var task = new Calculator();
            int a = 1;
            int b = 2;
            float expected = 2;
            task.Multiply(a, b);
            // Act
            float actual = task.Multiply(a, b);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest()
        {
            // Arrange
            var task = new Calculator();
            int a = 1;
            int b = 2;
            float expected = 0.5f;
            task.Divide(a, b);
            // Act
            float actual = task.Divide(a, b);
            // Assert
            Assert.AreEqual(expected, actual);
            //divide by zero
            // Arrange
            a = 1;
            b = 0;
            // Act
            // Assert
            Assert.ThrowsException<DivideByZeroException>(() => task.Divide(a, b));
        }

        [TestMethod()]
        public void AddTestbyFloat()
        {
            // Arrange
            var task = new Calculator();
            float a = 1.1f;
            float b = 2.2f;
            float expected = 3.3f;
            float tolerance = 0.0001f;
            // Act
            float actual = task.Add(a, b);
            // Assert
            Assert.AreEqual(expected, actual, tolerance);
        }
        [TestMethod()]
        public void devidedByDecimal()
        {
            // Arrange
            var task = new Calculator();
            float a = 1.1f;
            float b = 2.2f;
            float expected = 0.5f;
            // Act
            float actual = task.Divide(a, b);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}