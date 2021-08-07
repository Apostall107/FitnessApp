using FitnessAppLibrary.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessAppLibrary.BL.Controller
{
    [Serializable]
    public class TrainingController : BasicController
    {

        private readonly UserModel user;

        // TODO: see if needed to do as Dictionary kinda <user, trainig>
        public List<TrainingModel> userTrainingList{ get; }
        public List<ExerciseModel> exercisesList  { get; }


        public TrainingController(UserModel user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            userTrainingList = GetAllUserTrainingList();
            exercisesList = GetAllExercisesList();

        }
        public void Add(ExerciseModel exercise, DateTime begin, DateTime end)
        {
            var currebtEx = exercisesList.FirstOrDefault(a => a.Name == exercise.Name);

            if (currebtEx == null)
            {
                exercisesList.Add(exercise);

                TrainingModel training = new TrainingModel(begin, end, exercise, user);
                userTrainingList.Add(training);
            }
            else
            {
                var training = new TrainingModel(begin, end, currebtEx, user);
                userTrainingList.Add(training);
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
            base.Save(userTrainingList);
            base.Save(exercisesList);
        }



    }
}
