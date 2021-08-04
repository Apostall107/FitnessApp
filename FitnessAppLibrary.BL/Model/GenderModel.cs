using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{

    public class GenderModel
    {

        public string Name { get; set; }

        public GenderModel(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {

                throw new ArgumentNullException("Field cant be blank or null", nameof(name));

            }

            Name = name;

        }



        public override string ToString()
        {
            return base.ToString();
        }


    }


}

