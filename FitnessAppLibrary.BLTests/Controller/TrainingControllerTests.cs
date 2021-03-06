using FitnessAppLibrary.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FitnessAppLibrary.BL.Controller.Tests
{
    [TestClass()]
    public class TrainingControllerTests
    {


        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            string exerciseName = Guid.NewGuid().ToString();
            Random random = new Random();

            UserController userController = new UserController(userName);
            TrainingController trainingController = new TrainingController(userController.CurrentUser);
            ExerciseModel exercise = new ExerciseModel(exerciseName, random.Next(5, 500));

            //Act
            trainingController.Add(exercise, DateTime.Now.AddHours(-2), DateTime.Now.AddMinutes(-45));

            //Assert
            Assert.AreEqual(exercise.Name, trainingController.ExercisesList.Last().Name);
            Assert.AreEqual(exercise.CaloriesPerMinute, trainingController.ExercisesList.Last().CaloriesPerMinute);

        }
    }
}