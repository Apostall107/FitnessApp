using FitnessAppLibrary.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAppLibrary.BL.Controller
{
    public class UserController : BasicController
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
            }

            //GenderModel gender = new GenderModel(genderName);
        }


        private List<UserModel> GetUsersData()
        {

            return Load<UserModel>() ?? new List<UserModel>();

        }




        public void AddNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
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
            base.Save(Users);
        }


    }
}
