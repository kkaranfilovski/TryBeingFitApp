using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Data;
using TryBeingFitApp.Models.Enums;
using TryBeingFitApp.Models.Models;
using TryBeingFitApp.Services.Helpers;
using TryBeingFitApp.Services.Menus;

namespace TryBeingFitApp.Services.UserServices
{
    public class MainService
    {
        private StandardUserService standardService = new StandardUserService();
        private PremiumUserService premiumService = new PremiumUserService();
        private TrainerService trainerService = new TrainerService();

        public void StartApp()
        {
            StartMenu();
        }

        private void StartMenu()
        {
            while (true)
            {
                Screen.HomeScreen();
                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    LoginMenu();
                    continue;
                }
                else if(selection == "2")
                {
                    Register();
                    continue;
                }
                else if(selection == "3")
                {
                    Console.WriteLine("Thanks for using the app.");
                    Thread.Sleep(1500);
                    break;
                }
                else
                {
                    Helper.ShowSuccesMsg("Invalid selection. Try again");
                }
            }
        }

        private void LoginMenu()
        {
            var user = Login();
            if (user.Role == Roles.Standard)
            {
                standardService.Main(user);
            }
            else if (user.Role == Roles.Premium)
            {
                premiumService.Main(user);
            }
            else if (user.Role == Roles.Trainer)
            {
                trainerService.Main(user);
            }
        }

        private User Login()
        {
            while (true)
            {
                try
                {
                    string userName = Helper.GetUserName();
                    var user = InMemoryDatabase.GetUserByUserName(userName);
                    if (user != null)
                    {
                        string password = Helper.GetPassword();
                        if (user.Password == password)
                        {
                            Helper.ShowSuccesMsg($"Welcome {user.FirstName} {user.LastName}");
                            return user;
                        }
                        else
                        {
                            throw new Exception("Invalid password. Try again!");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid username. Try again.");
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }

        private static void Register()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Welcome to Register Menu");
                    string fName = Helper.ValidateName("name");
                    string lName = Helper.ValidateName("lastname");
                    string userName = Helper.ValidateUserName();
                    string password = Helper.ValidatePassword();
                    int age = Helper.ValidateAge();

                    var newUser = new User(fName, lName, age, userName, password, Roles.Standard);
                    InMemoryDatabase.AddNewUser(newUser);
                    Helper.ShowSuccesMsg("You have succesfully registered");
                    break;
                }
                catch (Exception ex)
                {
                    Helper.ShowErrorMsg(ex.Message);
                }
            }
        }
    }
}
