using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{
    public class PhysicalActivityModel
    {

        public string Name { get; set; }
        /// <summary>
        ///  Calories consumed per 1 minute of activity.
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        public PhysicalActivityModel(string name, double caloriesPerMinute)
        {
            // TODO: checks.

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }


        public override string ToString()
        {
            return "" ;
        }


    }
}
