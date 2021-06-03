
using Microsoft.Extensions.Configuration;
using ONE_Casa_Project.Views.Leave;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class ViewLeave
    {
        string connectionString;
        public IConfiguration config { get; set; }
        public ViewLeave(IConfiguration configure)
        {
            config = configure;
            connectionString = config["DbConnect"];
        }
        public List<LeaveColumn> getColumn()
        {
            DateTime today = DateTime.Today;
            int currentDate = DateTime.Today.Day;
            int currentMonth = DateTime.Today.Month;
            int lastMonth = DateTime.Today.AddMonths(-1).Month;
            int currentYear = DateTime.Today.Year;
            bool leap = DateTime.IsLeapYear(currentYear);
            int previousMonthDays = 0;
            int totalPreviousMonthDays = DateTime.DaysInMonth(currentYear, lastMonth);
            int start = 1, end = 28;
            List<LeaveColumn> column = new List<LeaveColumn>();

            if (currentDate < 12)
            {
                previousMonthDays = 12 - currentDate;
                start = totalPreviousMonthDays - previousMonthDays;
                end = currentDate + 15;
            }

            while (start <= totalPreviousMonthDays && previousMonthDays != 0)
            {
                column.Add(new LeaveColumn
                {
                    columnValue = today.AddMonths(-1).ToString("MMM") + " " + start,
                    date = today.AddMonths(-1).AddDays(start)
                });

                start++;

            }
            start = 1;
            while (start <= end)
            {
                column.Add(new LeaveColumn
                {
                    columnValue = today.ToString("MMM") + " " + start,
                    date = new DateTime(today.Year, today.Month, start)
                });

                start++;

            }
            return column;
        }
        public List<EmpDetailClass> allEmpId()
        {
            List<EmpDetailClass> id = new List<EmpDetailClass>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand("select distinct EmpName, EmpId from Leaves order by EmpId", con))
                {
                    con.Open();
                    SqlDataReader data = com.ExecuteReader();
                    while (data.Read())
                    {
                        EmpDetailClass val = new EmpDetailClass();
                        val.empId = Convert.ToInt32(data["EmpId"]);
                        val.empName = (data["EmpName"]).ToString();
                        id.Add(val);
                    }
                }
            }
            return id;
        }
        public List<LeaveData> data(int id)
        {
            List<LeaveData> values = new List<LeaveData>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand com = new SqlCommand("select EmpId, EmpName, fromDate, toDate, status, type from Leaves where EmpId = @id", con))
                {
                    com.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader data = com.ExecuteReader();
                    while (data.Read())
                    {
                        values.Add(new LeaveData()
                        {
                            fromDate = Convert.ToDateTime(data["fromDate"]),
                            toDate = Convert.ToDateTime(data["toDate"]),
                            status = data["status"].ToString(),
                            type = data["type"].ToString(),
                            empId = data["EmpId"].ToString(),
                            empName = data["EmpName"].ToString()
                        });
                    }

                }
            }
            return values;
        }
    }
}