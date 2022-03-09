using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core;
using Final_Project_ASP_MVC.Models;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUser();
            GetSponsorships();
        }
        public static void GetUser()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("ConfirmPassword:");
            string confirmPassword = Console.ReadLine();
            Console.WriteLine("Year:");
            int year = Int32.Parse(Console.ReadLine());

            User users = new User
            {
                UserName = name,
                Surname = surname,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                Year = year,             
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(users);
            if (!Validator.TryValidateObject(users, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }

        public static void GetSponsorships()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Command:");
            string command = Console.ReadLine();
            Console.WriteLine("Contract:");
            int contract = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Amount:");
            int amount = Int32.Parse(Console.ReadLine());

            Sponsorships sponsors = new Sponsorships
            {
                SponsorName = name,
                SponsorSurname = surname,
                Command = command,
                teamContract = contract,
                Amount = amount
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(sponsors);
            if (!Validator.TryValidateObject(sponsors, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }
    }
}
