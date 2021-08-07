using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessAppLibrary.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using FitnessAppLibrary.BL.Model;
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
            trainingController.Add(exercise, DateTime.Now.AddHours(-2) , DateTime.Now.AddMinutes(-45) );

            //Assert
            Assert.AreEqual(exercise.Name, trainingController.exercisesList.Last().Name);
            Assert.AreEqual(exercise.CaloriesPerMinute, trainingController.exercisesList.Last().CaloriesPerMinute);

        }
    }
}