using FitnessAppLibrary.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FitnessAppLibrary.BL.Controller.Tests
{
    [TestClass()]
    public class MealControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            string foodName = Guid.NewGuid().ToString();
            Random random = new Random();

            UserController userController = new UserController(userName);
            MealController mealController = new MealController(userController.CurrentUser);
            FoodModel food = new FoodModel(foodName, random.Next(5, 500), random.Next(5, 500), random.Next(5, 500), random.Next(5, 500));

            //Act
            mealController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, mealController.Meal.FoodList.Last().Key.Name);

        }
    }
}