using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class Employee
    {
        public int Id { get; set; }[Required]
        public string Name { get; set; }
        [Required]

        public DateTime Dob { get; set; }

        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string JobTitle { get; set; }

        public string JobRole { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public long Mobile { get; set; }
        [Required]

        public string ReportingManager { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public DateTime MarriageAnniversary { get; set; }
        [Required]

        public DateTime DateOfJoining { get; set; }
        [Required]
        public string SecondaryApprover { get; set; }
        [Required]
        public int InitialLeave { get; set; }
        [Required]
        public int InitialImmediate { get; set; }
        public DateTime LastWorkingDay { get; set; }




    }
}
