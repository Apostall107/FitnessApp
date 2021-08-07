using FitnessAppLibrary.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAppLibrary.BL.Controller
{
    public class MealController : BasicController
    {
        private readonly UserModel user;
        /// <summary>
        ///  List of food eaten during current meal.
        /// </summary>
        public List<FoodModel> FoodList { get; }
        /// <summary>
        ///  Single(current) meal of the user.
        /// </summary>
        public MealModel Meal { get; }
        public MealController(UserModel user)
        {
            this.user = user ?? throw new ArgumentNullException("\"User\" can not be empty.", nameof(user));
            FoodList = GetAllFoodList();
            Meal = GetMeal();
        }

        /// <summary>
        ///  Add name and weight of food eaten during the meal.
        ///  Checks if product was on our list of food for current meal.
        ///  If was found add weight to food eaten. if not add new product to list and its weight.
        /// </summary>
        public void Add(FoodModel food, double weight)
        {
            var product = FoodList.FirstOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                FoodList.Add(food);
                Meal.Add(food, weight);
                Save();
            }
            else
            {
                Meal.Add(product, weight);
                Save();
            }
        }



        private List<FoodModel> GetAllFoodList()
        {
            return Load<FoodModel>() ?? new List<FoodModel>();
        }


        private MealModel GetMeal()
        {
            return Load<MealModel>().FirstOrDefault() ?? new MealModel(user);
        }
        private void Save()
        {
            base.Save(FoodList);
            base.Save(new List<MealModel>() { Meal });
        }

    }
}
