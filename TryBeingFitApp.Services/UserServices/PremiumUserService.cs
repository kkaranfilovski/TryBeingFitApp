using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Data;
using TryBeingFitApp.Models.Models;
using TryBeingFitApp.Services.Helpers;
using TryBeingFitApp.Services.Interfaces;
using TryBeingFitApp.Services.Menus;

namespace TryBeingFitApp.Services.UserServices
{
    public class PremiumUserService : IUserService
    {
        public void Main(User user)
        {
            while (true)
            {
                Screen.PremiumUserMenu();
                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    Train(user);
                    continue;
                }
                else if (selection == "2")
                {
                    Account(user);
                }
                else if (selection == "3")
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

            while (true)
            {
                try
                {
                    Helper.ShowSuccesMsg($"GET READY TO TRAIN");


                    Screen.ChooseTypeOfTraining();
                    string typeoFTraining = Console.ReadLine();

                    if (typeoFTraining == "1")
                    {
                        VideoTraining(user);
                        break;
                    }
                    else if (typeoFTraining == "2")
                    {
                        LiveTraining(user);
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

        private void VideoTraining(User user)
        {
            while (true)
            {
                try
                {
                    int counter = 1;
                    var videoTrainings = InMemoryDatabase.GetAllVideoTrainings();
                    Console.WriteLine("Video trainings:");
                    foreach (var training in videoTrainings)
                    {
                        Console.WriteLine($"{counter}. {training.Title}");
                        counter++;
                    }

                    int selection = Helper.ParseInput(Console.ReadLine());

                    if (selection <= 0 || selection > videoTrainings.Count)
                    {
                        throw new Exception("Invalid choice. Try again.");
                    }
                    else
                    {
                        var videoTraining = videoTrainings[selection - 1];
                        user.VideoTrainings.Add(videoTraining);
                        Helper.ShowSuccesMsg($"Chosen training: {videoTraining.Title}");
                        Console.WriteLine("Training..........");
                        Thread.Sleep(3000);
                        Helper.ShowSuccesMsg("Training finished. Congrats");
                        Helper.RateTraining(videoTraining);
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

        private void LiveTraining(User user)
        {
            while (true)
            {
                try
                {
                    int counter = 1;
                    var liveTrainings = InMemoryDatabase.GetAllLiveTrainings();
                    Console.WriteLine("Live trainings:");
                    foreach (var training in liveTrainings)
                    {
                        Console.WriteLine($"{counter}. {training.Title}");
                        counter++;
                    }

                    int selection = Helper.ParseInput(Console.ReadLine());

                    if (selection <= 0 || selection > liveTrainings.Count)
                    {
                        throw new Exception("Invalid choice. Try again.");
                    }
                    else
                    {
                        var liveTraining = liveTrainings[selection - 1];
                        user.LiveTrainings.Add(liveTraining);
                        Helper.ShowSuccesMsg($"Chosen training: {liveTraining.Title}");
                        Console.WriteLine("Training..........");
                        Thread.Sleep(3000);
                        Helper.ShowSuccesMsg("Training finished. Congrats");
                        Helper.RateTraining(liveTraining);
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
            Console.WriteLine($"You have premium subscription");

            if(user.VideoTrainings.Count == 0 && user.LiveTrainings.Count == 0)
            {
                Console.WriteLine("You dont have trainings yet");
            }

            if (user.VideoTrainings.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Video Trainings:");
                user.VideoTrainings.ForEach(x => Console.WriteLine($"{x.Title} - {x.Description}"));
            }
            if(user.LiveTrainings.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Live Trainings:");
                user.LiveTrainings.ForEach(x => Console.WriteLine($"{x.Title} - {x.Description}"));
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to go back");
            Console.ReadLine();
        }
    }
}
