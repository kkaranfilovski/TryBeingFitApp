using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Models.Enums;
using TryBeingFitApp.Models.Models;

namespace TryBeingFitApp.Data
{
    public static class InMemoryDatabase
    {
        private static List<LiveTraining> LiveTrainings { get; set; }
        private static List<VideoTraining> VideoTrainings { get; set; }
        private static List<User> Users { get; set; }

        static InMemoryDatabase()
        {
            InitDatabase();
        }

        private static void InitDatabase()
        {
            Users = new List<User>
            {
                new User("kristijan", "karanfilovski", 26, "kiko1", "kiko123", Roles.Trainer),
                new User("stanko", "stankovski", 26, "stanko1", "stanko123", Roles.Trainer),
                new User("ilija", "mitev", 26, "ile1", "ile123", Roles.Standard),
                new User("petko", "petkovski", 30, "petko1", "petko123", Roles.Premium)
            };

            LiveTrainings = new List<LiveTraining>
            {
                new LiveTraining("biceps workout", "training for stronger arms", Users[0]),
            };

            VideoTrainings = new List<VideoTraining>
            {
                new VideoTraining("whole body workout", "training for stronger body", Users[1])
            };
        }

        public static User GetUserByUserName(string username)
        {
            return Users.FirstOrDefault(user => user.Username == username);
        }

        public static List<LiveTraining> GetAllLiveTrainings()
        {
            return LiveTrainings;
        }

        public static List<VideoTraining> GetAllVideoTrainings()
        {
            return VideoTrainings;
        }

        public static void AddNewUser(User user)
        {
            Users.Add(user);
        }
    }
}
