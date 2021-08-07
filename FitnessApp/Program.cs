using FitnessAppLibrary.BL.Controller;
using FitnessAppLibrary.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessApp
{
    class Program
    {


        static void Main(string[] args)
        {

            CultureInfo culture = new CultureInfo("en-us");
            ResourceManager resourceManager = new ResourceManager("FitnessApp.CDM.Language.Massages", typeof(Program).Assembly);



            Console.Clear();
            Console.WriteLine("StartupGreeting", culture);

            Console.WriteLine("Enter the user name.");
            string name = Console.ReadLine();



            UserController userController = new UserController(name);
            MealController mealController = new MealController(userController.CurrentUser);
            TrainingController trainingController = new TrainingController(userController.CurrentUser);



            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender :");
                string gender = Console.ReadLine();

                DateTime birthDate = ParseDateTime("birth date");

                double weight = ParseDouble("Weight");

                double height = ParseDouble("Height");


                userController.AddNewUserData(gender, birthDate, weight, height);

            }





            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("M - add new meal.");
                Console.WriteLine("T - add new training.");
                Console.WriteLine("E - exit.");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    //TODO: fix  that same food add to overall  weight of this product. Add dependency from date time. need to make energy value enter from product if it is added to list already
                    case ConsoleKey.M:
                        (FoodModel Food, double Weight) product = EnterNewMealData();
                        mealController.Add(product.Food, product.Weight);

                        foreach (var item in mealController.Meal.FoodList)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}g");
                        }
                        break;
                    case ConsoleKey.T:
                        var exe = EnterExercise();

                        trainingController.Add(exe.exercise, exe.Begin, exe.End);

                        foreach (var item in trainingController.UserTrainingList)
                        {
                            Console.WriteLine($"\t-{item.Exersice}: since {item.StartTime.ToShortTimeString()} to {item.FinishTime.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.E:
                        Environment.Exit(0);
                        break;
                }






                Console.ReadLine();





            }

        }


        #region EnterData

        private static (DateTime Begin, DateTime End, ExerciseModel exercise) EnterExercise()
        {
            Console.Write("Enter exercise naming:");
            string name = Console.ReadLine();

            double energy = ParseDouble("Enter energy consumption per 1 minute of exercise:");

            DateTime begin = ParseDateTime("Enter when exercise started:");
            DateTime end = ParseDateTime("Enter when exercise finished:");

            ExerciseModel exercise = new ExerciseModel(name, energy);
            return (begin, end, exercise);
        }

        private static (FoodModel Food, double Weight) EnterNewMealData()
        {
            Console.Write("Enter product name: ");
            var food = Console.ReadLine();

            Console.WriteLine("\n   Energy value:\n ");

            var calories = ParseDouble("Calories:");
            var prots = ParseDouble("Protein:");
            var fats = ParseDouble("Fat:");
            var carbs = ParseDouble("Carbohydrate:");

            var weight = ParseDouble("Weight of portion:");
            var product = new FoodModel(food, calories, prots, fats, carbs);


            return (Food: product, Weight: weight);
        }


        #endregion


        #region DataParsers

        private static DateTime ParseDateTime(string value)
        {
            DateTime dateValue;
            while (true)
            {
                Console.Write($"Enter your {value} (dd.mm.yyyy)/(dd.mm.yyyy hh:mm (for exercises)) : ");
                if (DateTime.TryParse(Console.ReadLine(), out dateValue))
                {
                    break;
                }
                else
                {
                    TryAgain(value);

                }
            }

            return dateValue;
        }



        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter the {name} :");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    TryAgain(value);
                }
            }
        }


        #endregion
        private static void TryAgain<T>(T value)
        {
            Console.WriteLine($"Invalid format  of {value} \nPlease press any key to try again.");
            Console.Read();
        }







    }
}
