using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessAppLibrary.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;

namespace FitnessAppLibrary.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {


        [TestMethod()]
        public void AddNewUserDataTest()
        {
            // Arrange
            string  userName = Guid.NewGuid().ToString();
            DateTime birthDate = DateTime.Now.AddYears(-18);
            double weight = 78;
            double height = 186;
            string genderName = "man";

            UserController controller = new UserController(userName);

            // Act
            controller.AddNewUserData(genderName, birthDate, weight, height);
            UserController controllerActual = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controllerActual.CurrentUser.Name);
            Assert.AreEqual(genderName, controllerActual.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controllerActual.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controllerActual.CurrentUser.Weight);
            Assert.AreEqual(height, controllerActual.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // AAA
            //Arrange
            string userName = Guid.NewGuid().ToString();


            //Act
            UserController controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);

        }


    }
}