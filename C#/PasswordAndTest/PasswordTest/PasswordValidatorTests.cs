using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Password;
namespace PasswordTest
{
    [TestClass]
    public class PasswordValidatorTests
    {
        [TestMethod]
        public void ValidPassword_ReturnsTrue()
        {
            //Arrange
            var validator = new PasswordValidator();
            string input = "Valid@123";
            //Act
            bool result = validator.isValidPassword(input);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EmptyPassword_ReturnsFalse()
        {
            //Arrange
            var validator = new PasswordValidator();
            string input = "";
            //Act
            bool result = validator.isValidPassword(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ShortPassword_ReturnsFalse()
        {
            //Arrange
            var validator = new PasswordValidator();
            string input = "Shor1@";
            //Act
            bool result = validator.isValidPassword(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void PasswordWithoutNumber_ReturnsFalse()
        {
            //Arrange
            var validator = new PasswordValidator();
            string input = "NoNumbers@";
            //Act
            bool result = validator.isValidPassword(input);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void PasswordWithoutSymbol_ReturnsFalse()
        {
            //Arrange
            var validator = new PasswordValidator();
            string input = "NoSpecial123";
            //Act
            bool result = validator.isValidPassword(input);
            //Assert
            Assert.IsFalse(result);
        }
    }
}
