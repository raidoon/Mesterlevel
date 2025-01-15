using Microsoft.VisualStudio.TestTools.UnitTesting;
using EgysegTeszt;
using System;

namespace MathOperations_UnitTest
{
    [TestClass]
    public class MathOperationsTests
    {
        [TestMethod] //teszteset
        public void MathOperationsAdd_PosToPos_ReturnsCorrectSum()
        {
            //Arrange
            var mathOperations = new MathOperations();
            //Act
            int result = mathOperations.Add(3, 5);
            //Assert
            Assert.AreEqual(8, result); //megnézzük, hogy a várt eredmény és a tényleges eredmény egyenlő-r
        }
    
        [TestMethod]
        public void MathOperationsAdd_NegToPos_ReturnsCorrectSum()
        {
                //Arrange
                var mathOperations = new MathOperations();
                //Act
                int result = mathOperations.Add(-3, 5);
                //Assert
                Assert.AreEqual(2, result); 
        }
        [TestMethod]
        public void MathOperationsAdd_NegToNeg_ReturnsCorrectSum()
        {
            //Arrange
            var mathOperations = new MathOperations();
            //Act
            int result = mathOperations.Add(-3, -5);
            //Assert
            Assert.AreEqual(-8, result);
        }
        [TestMethod]
        public void MathOperationsDiv_PosToPos_ReturnsCorrectRes()
        {
            //Arrange
            var mathOperations = new MathOperations();
            //Act
            double result = mathOperations.Divide(10, 5);
            //Assert
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void MathOperationsDiv_PosToNeg_ReturnsCorrectRes()
        {
            //Arrange
            var mathOperations = new MathOperations();
            //Act
            double result = mathOperations.Divide(10, -5);
            //Assert
            Assert.AreEqual(-2, result);
        }
        [TestMethod]
        public void MathOperationsDiv_NegToPos_ReturnsCorrectRes()
        {
            //Arrange
            var mathOperations = new MathOperations();
            //Act
            double result = mathOperations.Divide(-10, 5);
            //Assert
            Assert.AreEqual(-2, result);
        }
        [TestMethod]
        public void MathOperationsDiv_NegToNeg_ReturnsCorrectRes()
        {
            //Arrange
            var mathOperations = new MathOperations();
            //Act
            double result = mathOperations.Divide(-10, -5);
            //Assert
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MathOperationsDiv_DivideByZero_ReturnsCorrectRes()
        {
            //Arrange
            var mathOperations = new MathOperations();
            //Act
            double result = mathOperations.Divide(10, 0);
            //Assert
            //nem kerül be semmi most
        }
    }
}