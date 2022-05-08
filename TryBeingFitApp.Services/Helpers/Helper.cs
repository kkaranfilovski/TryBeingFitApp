using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Data;
using TryBeingFitApp.Models.Interfaces;
using TryBeingFitApp.Models.Models;
using TryBeingFitApp.Services.Menus;

namespace TryBeingFitApp.Services.Helpers
{
    public static class Helper
    {
        public static string GetUserName()
        {
            Console.Clear();
            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();
            return userName;
        }

        public static string GetPassword()
        {
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            return password;
        }

        public static int ParseInput(string input)
        {
            bool isValid = int.TryParse(input, out int number);
            if (!isValid)
            {
                throw new Exception("Invalid choice. Please enter a valid number");
            }
            else
            {
                return number;
            }
        }

        public static string ValidateName(string name)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Enter your {name}:");
                    string input = Console.ReadLine();

                    if (input.Length > 2)
                    {
                        return input;
                    }
                    else
                    {
                        throw new Exception($"{name} must be longer then 2 characters");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMsg(ex.Message);
                    continue;
                }

            }
        }

        public static string ValidateUserName()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your username:");
                    string username = Console.ReadLine();

                    if (username.Length > 5)
                    {
                        return username;
                    }
                    else
                    {
                        throw new Exception("Username must be longer then 5 characters");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }

        public static string ValidatePassword()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your password:");
                    string password = Console.ReadLine();

                    if (password.Length > 5 && DoesItContainNum(password))
                    {
                        return password;
                    }
                    else
                    {
                        throw new Exception("Password must be longer then 5 characters and contain number");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }

        public static int ValidateAge()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your age:");
                    int age = ParseInput(Console.ReadLine());

                    if(age >= 10 && age <= 70)
                    {
                        return age;
                    }
                    else
                    {
                        throw new Exception("You can register only if you are more then 10 and less then 70 years old.");
                    }
                    
                }
                catch (Exception ex)
                {
                    ShowErrorMsg(ex.Message);
                }
            }
                
        }

        private static bool DoesItContainNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str, i))
                {
                    return true;
                }
            }
            return false;
        }

        public static void RateTraining<T>(T training) where T : ITraining
        {
            while (true)
            {
                try
                {
                    Screen.RateTraining();
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("Enter rating from 1 to 5");
                        int rating = Helper.ParseInput(Console.ReadLine());
                        if (rating < 1 || rating > 5)
                        {
                            throw new Exception("Invalid rating. Please choose from 1 to 5");
                        }
                        else
                        {
                            training.UserRatings.Add(rating);
                            Helper.ShowSuccesMsg("Thanks for the feedback. See you next time");
                            break;
                        }
                    }
                    else if (choice == "2")
                    {
                        Helper.ShowSuccesMsg("See you next time");
                        break;
                    }
                    else
                    {
                        throw new Exception("Invalid choice. Try again.");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }

        public static void ShowErrorMsg<T>(T msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public static void ShowSuccesMsg<T>(T msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
            Thread.Sleep(1000);
        }
    }
}
