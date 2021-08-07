using FitnessAppLibrary.BL.Model;
using System.Data.Entity;




    public class FitnessContext : DbContext
    {

        public FitnessContext() : base("FintessAppDB") { }


        public DbSet<UserModel> Users { get; set; }
        public DbSet<GenderModel> Genders { get; set; }
        public DbSet<TrainingModel> Trainings { get; set; }
        public DbSet<MealModel> Meals { get; set; }
        public DbSet<ExerciseModel> Exercises { get; set; }
        public DbSet<FoodModel> Food { get; set; }

    }
