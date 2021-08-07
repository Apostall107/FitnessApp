using System;
using System.Collections.Generic;

namespace FitnessAppLibrary.BL.Model
{

    /// <summary>
    /// Contains data of exercise.
    /// </summary>
    [Serializable]
    public class ExerciseModel
    {


        #region Prop


        public int Id { get; set; }


        public string Name { get; set; }
        /// <summary>
        ///  Calories consumed per 1 minute of activity.
        /// </summary>
        public double CaloriesPerMinute { get; set; }


        public virtual ICollection<TrainingModel> Trainings { get; set; }



        #endregion



        public ExerciseModel() { }
        public ExerciseModel(string name, double caloriesPerMinute)
        {
            // TODO: checks.

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }


        public override string ToString()
        {
            return Name;
        }


    }
}
