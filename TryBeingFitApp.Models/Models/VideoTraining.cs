using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Models.Enums;
using TryBeingFitApp.Models.Interfaces;

namespace TryBeingFitApp.Models.Models
{
    public class VideoTraining : BaseEntity, ITraining
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TrainingTypes Type { get; set; }
        public double Rating { get; set; }
        public List<double> UserRatings { get; set; }
        public User Trainer { get; set; }
        public DateTime TimeOfTraining { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"Id: {Id} - Training Type: {Type}, Training: {Title}, Description: {Description}, Rating: {Rating}");
        }

        public VideoTraining(string title, string description, User trainer)
            : base()
        {
            Title = title;
            Description = description;
            if (trainer.Role == Roles.Trainer)
            {
                Trainer = trainer;
            }
            else
            {
                throw new Exception("That user is not a trainer.");
            }
            UserRatings = new List<double>();
            Type = TrainingTypes.Video;
            TimeOfTraining = DateTime.Now;
        }
    }
}
