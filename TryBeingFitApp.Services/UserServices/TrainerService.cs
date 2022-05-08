using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Models.Models;
using TryBeingFitApp.Services.Interfaces;

namespace TryBeingFitApp.Services.UserServices
{
    public class TrainerService : IUserService, ITrainerService
    {
        public void Main(User user)
        {

        }

        public void Account(User user)
        {
            throw new NotImplementedException();
        }

        public void RescheduleTraining()
        {
            throw new NotImplementedException();
        }

        public void Train(User user)
        {
            throw new NotImplementedException();
        }
    }
}
