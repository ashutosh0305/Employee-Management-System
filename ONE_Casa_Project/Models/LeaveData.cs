using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Views.Leave
{
    public class LeaveData
    {
        public string empName { get; set; }
        public string empId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string status { get; set; }
        public string type { get; set; }
    }
}
