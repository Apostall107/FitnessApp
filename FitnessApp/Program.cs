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
        static void Main(string[] args)
        {

            Console.Clear();
            Console.WriteLine("The \"FitnessApp\" welcomes you!");

            Console.WriteLine("Enter the user name.");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the user name.");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter the user name.");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the user name.");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the user name.");
            double height = double.Parse(Console.ReadLine());


            UserController userController  = new UserController(name, gender, birthDate, weight, height);

        }
    }
}
