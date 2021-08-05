using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{

    /// <summary>
    /// Taking of the meal process.
    /// </summary>
    [Serializable]
    class MealModel
    {

        public DateTime MealTime { get; }

        public Dictionary<FoodModel, double> FoodEnumeration { get; set; }

        public UserModel User { get; }
        public MealModel() { }

        public MealModel(UserModel user)
        {
            User = user ?? throw new ArgumentNullException("\"User\" can not be empty.", nameof(user));
            MealTime = DateTime.UtcNow;
            FoodEnumeration = new Dictionary<FoodModel, double>();
        }





    }


}
