using FitnessAppLibrary.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    class Program
    {
        //TODO: make them generic.
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter your {value} (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    TryAgain(value);

                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter your {name} :");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    TryAgain(value);
                }
            }
        }

        private static void TryAgain<T>(T value)
        {
            Console.WriteLine($"Invalid format  of {value} \nPlease press any key to try again.");
            Console.Read();
        }





        static void Main(string[] args)
        {

            Console.Clear();
            Console.WriteLine("The \"FitnessApp\" welcomes you!");

            Console.WriteLine("Enter the user name.");
            string name = Console.ReadLine();

            //Console.WriteLine("Enter the user name.");
            //string gender = Console.ReadLine();

            //Console.WriteLine("Enter the user name.");
            //DateTime birthDate = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the user name.");
            //double weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the user name.");
            //double height = double.Parse(Console.ReadLine());


            UserController userController = new UserController(name);


            //TODO: add checks. birth date.
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender :");
                string gender = Console.ReadLine();

                DateTime birthDate = ParseDateTime("birth date");
                
                double weight = ParseDouble("Weight");
           
                double height = ParseDouble("Height");


                userController.AddNewUserData(gender, birthDate, weight, height);

            }


            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();




        }
    }
}
