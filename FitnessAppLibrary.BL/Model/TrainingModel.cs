using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{
    /// <summary>
    /// Contains data of every training done.
    /// </summary>
    [Serializable]
    public class TrainingModel
    {
        // TODO: Look if needed to remake logic. Exercise model may contain calories per minute instead of PhysicalActivityModel and PhysActModel should be replaced with TrainigModel similar to FoodModel - MealModel.

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public ExerciseModel Exersice { get; set; }

        public UserModel User { get; set; }

        public TrainingModel(DateTime startTime, DateTime finishTime, ExerciseModel exercise, UserModel user)
        {
            //TODO: checks.

            StartTime = startTime;
            FinishTime = finishTime;
            Exersice = exercise;
            User = user;
        }
    }
}
