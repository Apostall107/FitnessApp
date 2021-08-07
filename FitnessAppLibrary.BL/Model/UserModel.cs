using System;

namespace FitnessAppLibrary.BL.Model
{
    /// <summary>
    /// Contains all user data.
    /// </summary>
    [Serializable]
    public class UserModel
    {

        #region Properties
        public string Name { get; }

        public GenderModel Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age
        {

            get
            {
                // Save today's date.
                DateTime today = DateTime.Today;

                // Calculate the age.
                int age = today.Year - BirthDate.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }

        }

        public double Weight { get; set; }

        public double Height { get; set; }
        #endregion

        public UserModel(string name, GenderModel gender, DateTime birthDate, double weight, double height)
        {

            #region Check
            if (string.IsNullOrWhiteSpace(name))
            {

                throw new ArgumentNullException("Name field can not be blank or Null.", nameof(name));

            }

            if (gender == null)
            {

                throw new ArgumentNullException("Gender field can not be blank or Null.", nameof(gender));

            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {

                throw new ArgumentException("Impossible birth date.", nameof(birthDate));

            }


            if (weight <= 0)
            {

                throw new ArgumentException("Weight can not be 0(zero) or less.", nameof(weight));

            }

            if (height <= 0)
            {

                throw new ArgumentNullException("Height can not be 0(zero) or less.", nameof(height));

            }

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public UserModel(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {

                throw new ArgumentNullException("Name field can not be blank or Null.", nameof(name));

            }

            Name = name;

        }

        public override string ToString()
        {
            return Name + " " + Age;
        }

    }
}
