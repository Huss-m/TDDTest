using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDTest1.Task.Task_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDTest1.Task.Task_2.Tests
{
    [TestClass()]
    public class StringProcessorTests
    {
        [TestMethod()]
        public void ToLowerCaseTest()
        {// Arrange
            StringProcessor stringProcessor = new StringProcessor();
            string input = "HELLO";
            string expected = "hello";
            // Act
            string result = stringProcessor.ToLowerCase(input);
            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void SanitizeTest()
        { // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            string input = "Hello!@#$%^&*()1234567890";
            string expected = "Hello1234567890";
            // Act
            string result = stringProcessor.Sanitize(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AreEqualTest()
        {//Arrange
            StringProcessor stringProcessor = new StringProcessor();
            string input1 = "Cloud!@#$%^&*()2024";
            string input2 = "Cloud2024";
                //Act
                bool result = stringProcessor.AreEqual(input1, input2);
            //Assert
            Assert.IsTrue(result);
        }
    }
}