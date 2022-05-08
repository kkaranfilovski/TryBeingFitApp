using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Models.Enums;
using TryBeingFitApp.Models.Models;

namespace TryBeingFitApp.Models.Interfaces
{
    public interface ITraining
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TrainingTypes Type { get; set; }
        public double Rating { get; set; }
        public List<double> UserRatings { get; set; }
        public User Trainer { get; set; }
        public DateTime TimeOfTraining { get; set; }
    }
}
