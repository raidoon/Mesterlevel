using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;
using System.Runtime.Versioning;
namespace CalculatorTest
{
    [TestClass]
    public class MathHelperTest
    {
        //---------------------------- ADD
        [TestMethod]
        public void Add_ReturnsCorrectValue_ForTwoNumbers()
        {
            var calculator = new MathHelper();
            int res = calculator.Add(2, 4);
            Assert.AreEqual(6, res);
        }
        //---------------------------- SUBSTRACT
        [TestMethod]
        public void Substract_ReturnsCorrectValue_ForTwoPosNumbers()
        {
            var calculator = new MathHelper();
            int res = calculator.Subtract(2, 4);
            Assert.AreEqual(-2, res);
        }
        [TestMethod]
        public void Substract_ReturnsCorrectValue_ForTwoNegNumbers()
        {
            var calculator = new MathHelper();
            int res = calculator.Subtract(-2, -4);
            Assert.AreEqual(2, res);
        }
        //---------------------------- MULTIPLY
        [TestMethod]
        public void Multiply_ReturnsCorrectValue_ForTwoPosNumbers()
        {
            var calculator = new MathHelper();
            int res = calculator.Multiply(2, 4);
            Assert.AreEqual(8, res);
        }
        [TestMethod]
        public void Multiply_ReturnsCorrectValue_ForTwoNegNumbers()
        {
            var calculator = new MathHelper();
            int res = calculator.Multiply(-5, -5);
            Assert.AreEqual(25, res);
        }
        //---------------------------- DIVIDE
        [TestMethod]
        public void Divide_ReturnsCorrectValue_ForTwoNumberS()
        {
            var calculator = new MathHelper();
            double res = calculator.Divide(6, 3);
            Assert.AreEqual(2, res);
        }
        [TestMethod]
        public void Divide_ReturnsZero_ForZeroSubstractingSmth()
        {
            var calculator = new MathHelper();
            int res = calculator.Divide(0, 2);
            Assert.AreEqual(0, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Divide_ReturnsException_ForSubstractingWithZero()
        {
            var calculator = new MathHelper();
            double res = calculator.Divide(2, 0);
        }
    }
}