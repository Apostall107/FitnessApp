using FitnessAppLibrary.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessAppLibrary.BL.Controller
{
    public class UserController
    {
        public UserModel User { get; }
        

        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            GenderModel gender = new GenderModel(genderName);
            User = new UserModel(userName, gender, birthDate, weight, height);

        }



        /// <summary>
        /// Save user data.
        /// </summary>
        /// <returns></returns>
        public void Save()
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat",  FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, User);

            }

        }


        /// <summary>
        /// Get user data.
        /// </summary>
        /// <returns>User of Application.</returns>
        public UserModel Load()
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                return formatter.Deserialize(fs) as UserModel ;

            }


        }


    }
}
