using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{
    [Serializable]
    public class GenderModel
    {

        public string Name { get; set; }

        public GenderModel(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {

                throw new ArgumentNullException("Field can not be blank or Null", nameof(name));

            }

            Name = name;

        }



        public override string ToString()
        {
            return Name;
        }


    }


}

