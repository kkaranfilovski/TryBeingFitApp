using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBeingFitApp.Models.Models
{
    public abstract class BaseEntity
    {
        public static int IdCounter { get; set; } = 0;
        public int Id { get; set; }
        public abstract void GetInfo();

        public BaseEntity()
        {
            Id = IdCounter += 1;
        }
    }
}
