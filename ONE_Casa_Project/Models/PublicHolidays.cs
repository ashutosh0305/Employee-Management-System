using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class PublicHolidays
    {
        public int Id { get; set; }
        public DateTime Dates { get; set; }
        public string HolidayName { get; set; }
        public string Department { get; set; }
    }
}
