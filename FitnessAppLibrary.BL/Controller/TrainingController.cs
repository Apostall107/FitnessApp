using FitnessAppLibrary.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAppLibrary.BL.Controller
{
    [Serializable]
    public class TrainingController : BasicController
    {

        private readonly UserModel user;

        // TODO: see if needed to do as Dictionary kinda <user, trainig>
        public List<TrainingModel> UserTrainingList { get; }
        public List<ExerciseModel> ExercisesList { get; }


        public TrainingController(UserModel user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            UserTrainingList = GetAllUserTrainingList();
            ExercisesList = GetAllExercisesList();

        }
        public void Add(ExerciseModel exercise, DateTime begin, DateTime end)
        {
            var currebtEx = ExercisesList.FirstOrDefault(a => a.Name == exercise.Name);

            if (currebtEx == null)
            {
                ExercisesList.Add(exercise);

                TrainingModel training = new TrainingModel(begin, end, exercise, user);
                UserTrainingList.Add(training);
            }
            else
            {
                var training = new TrainingModel(begin, end, currebtEx, user);
                UserTrainingList.Add(training);
            }
            Save();
        }

        private List<ExerciseModel> GetAllExercisesList()
        {
            return Load<ExerciseModel>() ?? new List<ExerciseModel>();
        }

        private List<TrainingModel> GetAllUserTrainingList()
        {
            return Load<TrainingModel>() ?? new List<TrainingModel>();
        }

        private void Save()
        {
            base.Save(UserTrainingList);
            base.Save(ExercisesList);
        }



    }
}
