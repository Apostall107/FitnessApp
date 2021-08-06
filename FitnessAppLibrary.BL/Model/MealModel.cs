using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{

    /// <summary>
    /// Taking of the meal process.
    /// </summary>
    [Serializable]
    public class MealModel
    {
        /// <summary>
        ///  Time when user take a meal.
        /// </summary>
        public DateTime MealTime { get; }

        /// <summary>
        /// List of food user eaten/
        /// </summary>
        public Dictionary<FoodModel, double> FoodList { get; set; }

        public UserModel User { get; }
        public MealModel() { }

        public MealModel(UserModel user)
        {
            User = user ?? throw new ArgumentNullException("\"User\" can not be empty.", nameof(user));
            MealTime = DateTime.UtcNow;
            FoodList = new Dictionary<FoodModel, double>();
        }


        /// <summary>
        ///  Add food to current meal.
        /// </summary>
        public void Add(FoodModel food, double weight)
        {
            FoodModel product = FoodList.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                FoodList.Add(food, weight);
            }
            else
            {
                FoodList[product] += weight;
            }
        }


    }


}
