using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class IndividualLeave
    {

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double LeaveBalance { get; set; }
        public double ImmediateBalance { get; set; }
    }
}
