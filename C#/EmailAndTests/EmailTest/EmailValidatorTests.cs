using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Email;

namespace EmailTest
{
    [TestClass]
    public class EmailValidatorTests
    {
        [TestMethod]
        public void ValidEmail_ReturnsTrue()
        {
            //Arrange
            var validator = new EmailValidator();
            string input = "test@example.com";
            //Act
            bool result = validator.IsValidEmail(input);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EmptyEmail_ReturnsFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string input = "";
            //Act
            bool result = validator.IsValidEmail(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EmailWithoutASymbol_ReturnsFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string input = "testexample.com";
            //Act
            bool result = validator.IsValidEmail(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EmailWithMultipleAtSymbol_ReturnsFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string input = "test@@example.com";
            //Act
            bool result = validator.IsValidEmail(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EmailWithoutDomain_ReturnsFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string input = "test@";
            //Act
            bool result = validator.IsValidEmail(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EmailWithoutLocal_ReturnsFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string input = "@example.com";
            //Act
            bool result = validator.IsValidEmail(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EmailWithoutTLD_ReturnsFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string input = "test@example";
            //Act
            bool result = validator.IsValidEmail(input);
            //Assert
            Assert.IsFalse(result);
        }
    }
}