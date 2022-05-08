using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Data;
using TryBeingFitApp.Models.Enums;
using TryBeingFitApp.Models.Models;
using TryBeingFitApp.Services.Helpers;
using TryBeingFitApp.Services.Interfaces;
using TryBeingFitApp.Services.Menus;

namespace TryBeingFitApp.Services.UserServices
{
    public class StandardUserService : IUserService, IStandardUserService
    {

        public void Main(User user)
        {
            while (true)
            {
                Screen.StandardUserMenu();
                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    Train(user);
                    continue;
                }
                else if (selection == "2")
                {
                    UpgradeToPremium(user);
                    break;
                }
                else if (selection == "3")
                {
                    Account(user);
                }
                else if (selection == "4")
                {
                    Helper.ShowSuccesMsg("Thanks for visiting us. Hope to see you soon");
                    break;
                }
                else
                {
                    Helper.ShowErrorMsg("Invalid selection. Try again");
                    continue;
                }
            }
        }

        public void Train(User user)
        {

            var trainigs = InMemoryDatabase.GetAllVideoTrainings();
            while (true)
            {
                try
                {
                    Helper.ShowSuccesMsg($"GET READY TO TRAIN");
                    Console.WriteLine("To start choose one of the following trainings");
                    int counter = 1;

                    foreach (var training in trainigs)
                    {

                        Console.WriteLine($"{counter}. {training.Title}");
                        counter++;

                    }

                    int selection = Helper.ParseInput(Console.ReadLine());

                    if (selection < 0 || selection > trainigs.Count)
                    {
                        throw new Exception("Invalid choice. Try again.");
                    }
                    else
                    {
                        var training = trainigs[selection - 1];
                        user.VideoTrainings.Add(training);
                        Helper.ShowSuccesMsg($"Chosen training: {training.Title}");
                        Console.WriteLine("Training..........");
                        Thread.Sleep(3000);
                        Helper.ShowSuccesMsg("Training finished. Congrats");
                        Helper.RateTraining(training);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }

        public void Account(User user)
        {
            Console.WriteLine($"You have standard subscription");
            if (user.VideoTrainings.Count > 0)
            {
                Console.WriteLine("Trainings:");
                user.VideoTrainings.ForEach(x => Console.WriteLine($"{x.Title} - {x.Description}"));
            }
            else
            {
                Console.WriteLine("You dont have trainings yet. GO TRAIN!");
            }

            Console.WriteLine("Press any key to go back");
            Console.ReadLine();
        }

        public void UpgradeToPremium(User user)
        {
            while (true)
            {
                try
                {
                    Screen.UpgradeToPremium();
                    string selection = Console.ReadLine();

                    if (selection == "1")
                    {
                        user.Role = Roles.Premium;
                        Helper.ShowSuccesMsg("Your account is upgraded to premium. You need to log in again to have premium options.");
                        break;
                    }
                    else if (selection == "2")
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Invalid selection. Try again");
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }
    }
}
