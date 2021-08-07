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


        #region Prop

        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public int ExersiceId { get; set; }

        public virtual ExerciseModel Exersice { get; set; }

        public int UserId { get; set; }

        public virtual UserModel User { get; set; }

        #endregion




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
