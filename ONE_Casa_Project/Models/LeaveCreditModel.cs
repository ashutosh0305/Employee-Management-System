using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class LeaveCreditModel
    {


        public int EmpId { get; set; }
        public string Type { get; set; }
        public double TotalLeave { get; set; }
        public double ImmediateLeave { get; set; }
        public double Amount { get; set; }
        public DateTime OnDate { get; set; }
        public string Note { get; set; }
    }
}
