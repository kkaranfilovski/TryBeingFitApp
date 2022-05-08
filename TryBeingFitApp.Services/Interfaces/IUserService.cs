using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFitApp.Models.Models;

namespace TryBeingFitApp.Services.Interfaces
{
    public interface IUserService
    {
        public void Train(User user);
        public void Account(User user);
    }
}
