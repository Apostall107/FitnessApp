using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{
    /// <summary>
    /// Food  and it`s energy data.
    /// </summary>
    [Serializable]
    public class FoodModel
    {



        #region Prop

        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Proteins/100g of product.
        /// </summary>
        public double Protein { get; set; }

        /// <summary>
        /// Fats/100g of product.
        /// </summary>
        public double Fat { get; set; }

        /// <summary>
        /// Carbohydrates/100g of product.
        /// </summary>
        public double Carbohydrate { get; set; }

        /// <summary>
        /// Calories/100g of product.
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        ///  Energy in kilojoules.
        /// </summary>
        public double Energy
        {
            get
            {

                if (Calories > 0)
                {
                    return Calories * 4.1868;
                }
                else
                {

                    return 0;

                }

            }

        }



        public virtual ICollection<MealModel> Meals { get; set; }

        #endregion




        public FoodModel() { }

        public FoodModel(string name) : this(name, 0, 0, 0, 0) { }

        public FoodModel(string name, double callories, double protein, double fat, double carbohydate)
        {
            // TODO: checks

            Name = name;
            Calories = callories / 100.0;
            Protein = protein / 100.0;
            Fat = fat / 100.0;
            Carbohydrate = carbohydate / 100.0;

        }



        public override string ToString()
        {
            return Name;
        }



    }
}
