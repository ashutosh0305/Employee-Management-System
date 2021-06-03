using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class LeaveSummeryReport
    {
      public int id { get; set; }
          public string name { get; set; }
          public string department { get; set; }
          public int  InitialImmediateInstance { get; set; }
          public int AddedImmediateinThisMonth { get; set; }
          public int OpeningImmediateInstance { get; set; }
          public int MonthlyLeaveFactor { get; set; }
          public int JoiningLeaveFactor { get; set; }
          public int  ImmediateLeave { get; set; }
          public string role { get; set; }

    }
}
