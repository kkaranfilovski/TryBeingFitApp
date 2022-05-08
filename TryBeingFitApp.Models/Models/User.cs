using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Models.Enums;
using TryBeingFitApp.Models.Interfaces;

namespace TryBeingFitApp.Models.Models
{
    public class User : BaseEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public List<LiveTraining> LiveTrainings { get; set; } = new List<LiveTraining>();
        public List<VideoTraining> VideoTrainings { get; set; } = new List<VideoTraining>();


        public override void GetInfo()
        {
            Console.WriteLine($"Id: {Id} - User: {FirstName} {LastName}, Age: {Age}, Role: {Role}");
        }

        public User(string fName, string lName, int age, string username, string password, Roles role)
            :base()
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
