using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace PowerCalculatorTests
{
    [TestClass]
    public class PowerCalculatorTests
    {
        [TestMethod]
        public void TestPositiveExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = 2;
            int b = 3;
            //Act
            double result = calculator.CalculatePower(a,b);
            //Assert
            Assert.AreEqual(8, result);
        }
        [TestMethod]
        public void TestZeroExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = 5;
            int b = 0;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestNegativeExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = 2;
            int b = -2;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(0.25, result);
        }
        [TestMethod]
        public void TestZeroBasePositiveExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = 0;
            int b = 5;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void TestZeroBaseZeroExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = 0;
            int b = 0;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestOneBaseAnyExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = 1;
            int b = 100;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestNegativeBaseEvenExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = -3;
            int b = 4;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(81, result);
        }
        [TestMethod]
        public void TestNegativeBaseOddExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = -2;
            int b = 3;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(-8, result);
        }
        [TestMethod]
        public void TestNegativeBaseNegativeExponent()
        {
            //Arrange
            var calculator = new PowerCalculator();
            int a = -2;
            int b = -2;
            //Act
            double result = calculator.CalculatePower(a, b);
            //Assert
            Assert.AreEqual(0.25, result);
        }
    }
}