using System;
using System.Collections.Generic;

namespace FitnessAppLibrary.BL.Model
{
    [Serializable]
    public class GenderModel
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public virtual ICollection<UserModel> Users { get; set; }



        public GenderModel() { }
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

