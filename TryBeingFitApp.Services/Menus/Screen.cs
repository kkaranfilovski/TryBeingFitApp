using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBeingFitApp.Services.Menus
{
    public static class Screen
    {
        public static void HomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***** TRY BEING FIT *****");
            Console.ResetColor();
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
        }

        public static void StandardUserMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("1. Train");
            Console.WriteLine("2. Upgrade to premium");
            Console.WriteLine("3. Account");
            Console.WriteLine("4. Log out");
        }

        public static void PremiumUserMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("1. Train");
            Console.WriteLine("2. Account");
            Console.WriteLine("3. Log out");
        }

        public static void TrainerMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("1. Reschedule training");
            Console.WriteLine("2. Account");
            Console.WriteLine("3. Log out");
        }

        public static void RateTraining()
        {
            Console.Clear();
            Console.WriteLine("Do you want to rate the training:");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. Next time");
        }

        public static void UpgradeToPremium()
        {
            Console.Clear();
            Console.WriteLine("Premium account price is 10$. In addition of video trainings you can have Live trainings as well.");
            Console.WriteLine("Do you want to upgrade to premium?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        public static void ChooseTypeOfTraining()
        {
            Console.WriteLine("To start choose one of the following trainings");
            Console.WriteLine("1. Video Training");
            Console.WriteLine("2. Live Training");
        }
    }
}
