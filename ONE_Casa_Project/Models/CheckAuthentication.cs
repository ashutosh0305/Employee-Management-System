using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ONE_Casa_Project.Models;
using ONE_Casa_Project.Controllers;

namespace ONE_Casa_Project.Models
{
    public class CheckAuthentication
    {
        string ConnectionString;
        public IConfiguration Configuration { get; }
        public CheckAuthentication(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["DbConnect"];
        }
        public string CheckRole(int? Check)
        {
            String Final;
            if (Check != null)
            {
                using (SqlConnection Con = new SqlConnection(ConnectionString))
                {
                    SqlCommand Command = new SqlCommand("Select * from Employee where id=@id ", Con);
                    Command.Parameters.AddWithValue("@id", Check);
                    Con.Open();

                    SqlDataReader Data = Command.ExecuteReader();
                    Data.Read();
                    Final = Data["role"].ToString();
                }
            }
            else
            {
                return "NoData";
            }
            return Final;
        }

        //public ActionResult Check(string fname)
        //{
        //    fname = TempData["Email"].ToString();
        //    EmployeeServices Es = new EmployeeServices(Configuration);
        //    Employee Member;
        //    List<Employee> Data = Es.GetAllData();
        //    Data.ForEach(x =>
        //    {
        //        if (x.email == fname)
        //        {
        //            Member = x;
        //            HttpContext.Session.SetInt32("id", x.employeeId);
        //        }
        //    });
        //    return RedirectToAction("Dashboard", "Employee");
        //}
    }
}