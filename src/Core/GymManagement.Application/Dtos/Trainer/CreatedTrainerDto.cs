using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Dtos.Trainer
{
    public class CreatedTrainerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
