using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{
    public class ExerciseModel
    {
        // TODO: Look if needed to remake logic. Exercise model may contain calories per minute instead of PhysicalActivityModel and PhysActModel should be replaced with TrainigModel similar to FoodModel - MealModel.

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public PhysicalActivityModel PhysicalActivity { get; set; }

        public UserModel User { get; set; }

        public ExerciseModel(DateTime startTime, DateTime finishTime, PhysicalActivityModel physicalActivity, UserModel user)
        {
            //TODO: checks.

            StartTime = startTime;
            FinishTime = finishTime;
            PhysicalActivity = physicalActivity;
            User = user;
        }
    }
}
