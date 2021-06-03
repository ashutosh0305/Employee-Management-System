using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class Leaves
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime  FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public string Description { get; set; }

        public DateTime CurrentDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        public string LeaveType { get; set; }
        public int  TotalLeave { get; set; }
        public int TakenLeave { get; set; }
          
           

    }
}



