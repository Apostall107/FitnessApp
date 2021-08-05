using FitnessAppLibrary.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessAppLibrary.BL.Controller
{
    public class UserController
    {
        public List<UserModel> Users { get; }
        public UserModel CurrentUser { get; }

        public bool IsNewUser { get; } = false;


        public UserController(string userName)
        {

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can not be empty.", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.FirstOrDefault(x => x.Name == userName);


            if (CurrentUser == null)
            {
                CurrentUser = new UserModel(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

            //GenderModel gender = new GenderModel(genderName);
        }


        private List<UserModel> GetUsersData()
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formatter.Deserialize(fs) is List<UserModel> users)
                {
                    return users;
                }
                else
                {
                    return new List<UserModel>();
                }

            }

        }




        public void AddNewUserData(string genderName, DateTime birthDate, double weight = 0, double height = 0)
        {
            //TODO: add checks.

            CurrentUser.Gender = new GenderModel(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }


        //public static bool IsDateTime(string txtDate)
        //{
        //    DateTime tempDate;
        //    return DateTime.TryParse(txtDate, out tempDate);
        //}




        public void Save()
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, Users);

            }

        }


    }
}
