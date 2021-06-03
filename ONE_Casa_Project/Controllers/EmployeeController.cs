using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ONE_Casa_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Controllers
{
    public class EmployeeController : Controller
    {
        public IConfiguration Configuration { get; }
        public EmployeeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [Route("Employee/Dashboard")]
        public IActionResult Dashboard()
        {
            LeaveServices ls = new LeaveServices(Configuration);
            int? data = HttpContext.Session.GetInt32("id");
            int data1 = Convert.ToInt32(data);
            int data2= ls.takenfordash(data1);
            if(data2==-1)
            {
                data2 = 0;
            }
         
            int data3= ls.pendingfordash(data1);
            if (data3 == -1)
            {
                data2 = 0;
            }
            int data4= ls.pendingforApproved(data1);
            if (data4 == -1)
            {
                data4 = 0;
            }
            int data5= ls.Rejectfordash(data1);
            if (data5 == -1)
            {
                data5 = 0;
            }
            int data6= ls.Canceledfordash(data1);
            if (data6 == -1)
            {
                data6 = 0;
            }
            ViewBag.taken = data2;
            ViewBag.pending = data3;
            ViewBag.Approved = data4;
            ViewBag.Reject = data5;
            ViewBag.Canceled = data6;
            return View();
           
        }


        public string findname()
        {
            EmployeeServices es = new EmployeeServices(Configuration);

            
            int? data = HttpContext.Session.GetInt32("id");
            int data1 = Convert.ToInt32(data);
            string name = es.findnameservice(data1);



          return name;


        }

        // GET: Employee
        public ActionResult Index()
        {
            var data = new EmployeeServices(Configuration);
            List<Employee> Emp = data.GetAllData();
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.role = Check;
                return View(Emp);
            }
     
           
        }
        public ActionResult Getemployee(string fname)
        {
          
            var data = new EmployeeServices(Configuration);
            List<Employee> Emp = data.Getemployee(fname);
            return View(Emp);
        }
        public ActionResult active()
        {

            var data = new EmployeeServices(Configuration);
            List<Employee> Emp = data.isactive();
            return View(Emp);
        }

        public ActionResult inactive()
        {

            var data = new EmployeeServices(Configuration);
            List<Employee> Emp = data.isinactive();
            return View(Emp);
        }


        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            var data = new EmployeeServices(Configuration);
            List<Employee> Emp = data.GetAllData();

            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Emp = Emp;
                ViewBag.Job = data.GetJobTitle();
                ViewBag.Depa = data.getDepartment();
                return View();
            }

        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee collection)
        {
            try
            {
                CheckAuthentication Ca = new CheckAuthentication(Configuration);
                string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
                if (Check != "Admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    EmployeeServices Operation = new EmployeeServices(Configuration);
                    Operation.SetNewEmployee(collection);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                EmployeeServices Operation = new EmployeeServices(Configuration);
                Employee employee = Operation.GetOneEmployee(id);
                List<Employee> Emp = Operation.GetAllData();
                ViewBag.Emp = Emp;
                ViewBag.Job = Operation.GetJobTitle();
                ViewBag.Depa = Operation.getDepartment();

                return View(employee);
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee collection)
        {
            try
            {
                CheckAuthentication Ca = new CheckAuthentication(Configuration);
                string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
                if (Check != "Admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    EmployeeServices Operation = new EmployeeServices(Configuration);

                    Operation.UpdateEmployee(collection);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
