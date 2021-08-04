using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.BL.Model
{
    public class UserModel
    {

        #region Properties
        public string Name { get;  }

        public GenderModel Gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }
        #endregion

        public UserModel(string name, GenderModel gender, DateTime birthDate, double weight, double height)
        {

            #region Check
            if (string.IsNullOrWhiteSpace(name))
            {

                throw new ArgumentNullException("Name field cant be blank or null.", nameof(name));

            }

            if (gender == null)
            {

                throw new ArgumentNullException("Gender field cant be blank or null.", nameof(gender));

            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {

                throw new ArgumentException("Impossible birth date.", nameof(birthDate));

            }


            if (weight <= 0)
            {

                throw new ArgumentException("Weight cant be 0(zero) or less.", nameof(weight));

            }

            if (height <= 0)
            {

                throw new ArgumentNullException("Height cant be 0(zero) or less.", nameof(height));

            }

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
