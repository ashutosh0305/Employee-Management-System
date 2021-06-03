using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ONE_Casa_Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


       

        public ActionResult Index()
        {
            //if (HttpContext.Session.GetInt32("id") == null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Dashboard", "Employee");
            //}
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("GoogleLogin", "Account");
            }
            else
            {
                //return View();
                return RedirectToAction("Dashboard", "Employee");
            }
        }
        public ActionResult start()
        {
           return View();
            
        }

        //public ActionResult check(string fname)
        //{
        //    EmployeeServices Es = new EmployeeServices(Configuration);
        //    //Employee Member;
        //    List<Employee> Data = Es.GetAllData();
        //    Data.ForEach(x =>
        //    {
        //        if (x.Email == fname)
        //        {
        //            //Member = x;
        //            HttpContext.Session.SetInt32("id", x.Id);
        //        }
        //    });
        //    return RedirectToAction("Index", "Home");
        //}



        public ActionResult Check(string fname)
        {
            fname = TempData["Email"].ToString();
            EmployeeServices Es = new EmployeeServices(Configuration);
            Employee Member;
            List<Employee> Data = Es.GetAllData();
            Data.ForEach(x =>
            {
                if (x.Email == fname)
                {
                    Member = x;
                    HttpContext.Session.SetInt32("id", x.Id);
                }
            });
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction("start", "Home");
        }

        public int Checkwho()
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
