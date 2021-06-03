
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ONE_Casa_Project.Models;
using ONE_Casa_Project.Views.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneCasa.Controllers
{
    public class LeaveController : Controller
    {
        public IConfiguration Configuration { get; }
        public LeaveController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET: LeaveController
        public ActionResult Index()
        {
            ViewLeave data = new ViewLeave(Configuration);
            List<LeaveColumn> column = data.getColumn();
            List<List<LeaveData>> allValues = new List<List<LeaveData>>();
            List<EmpDetailClass> allEmpId = data.allEmpId();

            foreach (var id in allEmpId)
            {
                List<LeaveData> val = data.data(id.empId);
                allValues.Add(val);
            }
            ViewBag.AllEmp = allEmpId;
            ViewBag.column = column;
            ViewBag.allValues = allValues;

            //Console.WriteLine(allValues.ElementAt(0).ElementAt(0));
            return View();
        }

        public ActionResult ApplyLeave()
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                var data = new EmployeeServices(Configuration);
                List<Employee> Emp = data.GetAllData();
                ViewBag.Emp = Emp;
                return View();
            }
            else
            {
                if (Check == "NoData")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    EmployeeServices Es = new EmployeeServices(Configuration);
                    int? data = HttpContext.Session.GetInt32("id");
                    int data1 = Convert.ToInt32(data);
                    Employee employee = Es.GetOneEmployee(data1);
                    ViewBag.Name = employee.Name;
                    return View();
                }
            }
        }


        [HttpPost]
        public ActionResult ApplyLeave(Leaves LeaveData)
        {
            LeaveServices Ls = new LeaveServices(Configuration);
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
            }
            else
            {
                if (Check == "NoData")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    int? data = HttpContext.Session.GetInt32("id");
                    int data1 = Convert.ToInt32(data);
                    LeaveData.EmpId = data1;
                }

            }
            Ls.ApplyLeave(LeaveData);
            return RedirectToAction("ApplyLeave");
        }



        public string CheckPlannned(DateTime FromDate, DateTime ToDate, TimeSpan FromTime, TimeSpan ToTime, string Status)
        {
            LeaveServices Ls = new LeaveServices(Configuration);
            int check = Ls.CheckPlannned(FromDate, ToDate, FromTime, ToTime, Status);
            var data = Convert.ToInt32(FromDate.Subtract(DateTime.Now).Days) + 1;
            if (data < check)
            {
                return "UnPlanned";
            }
            else
            {
                return "Planned";
            }
        }

        public ActionResult Pending()
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                List<Leaves> leave = Ls.AllLeave();
                return View(leave);
            }
            else
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                
                int? data = HttpContext.Session.GetInt32("id");
                int data1 = Convert.ToInt32(data);
                List<Leaves> leave = Ls.findpersonleave(data1);
                return View(leave);
                //return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult PendingEdit(int Id)
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                Leaves Data = Ls.PendingEdit(Id);
                return View(Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult PendingEdit(Leaves Leave)
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                Ls.PendingEditUpdate(Leave);
                return RedirectToAction("Pending");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult PublicHoliday()
        {
            SettingServices Ph = new SettingServices(Configuration);
            List<PublicHolidays> Holiday = Ph.PublicHoliday();

            return View(Holiday);
        }

        public ActionResult Taken()
        {
            LeaveServices Ls = new LeaveServices(Configuration);
            List<Leaves> leave = Ls.AllLeave();
            return View(leave);

        }


        public ActionResult Action()
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                List<Leaves> leave = Ls.AllPendingLeave();
                return View(leave);
            }
            else
            {
                if (Check == "NotAdmin")
                {
                    EmployeeServices Es = new EmployeeServices(Configuration);
                    int? data = HttpContext.Session.GetInt32("id");
                    if (data == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        int data1 = Convert.ToInt32(data);
                        Employee employee = Es.GetOneEmployee(data1);
                        LeaveServices Ls = new LeaveServices(Configuration);
                        List<Employee> employees = Ls.GetRepManagerEmployee(employee);
                        List<Leaves> leaves = Ls.GetRepManagerLeaveEmployee(employees);
                        return View(leaves);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
        }


        public ActionResult Approve(int id)
        {
            LeaveServices Ls = new LeaveServices(Configuration);
            bool status = Ls.Approve(id);
            if (status)
            {
                return RedirectToAction("Action");
            }
            else
            {
                return RedirectToAction("Action");
            }
        }
        public ActionResult Cacel(int id)
        {
            LeaveServices Ls = new LeaveServices(Configuration);
            bool status = Ls.Cacel(id);
            if (status)
            {
                return RedirectToAction("Action");
            }
            else
            {
                return RedirectToAction("Action");
            }
        }
        public ActionResult Reject(int id)
        {
            LeaveServices Ls = new LeaveServices(Configuration);
            bool status = Ls.Reject(id);
            if (status)
            {
                return RedirectToAction("Action");
            }
            else
            {
                return RedirectToAction("Action");
            }
        }


        public ActionResult TakenPreview()
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                List<Leaves> leave = Ls.TakenPreview();
                return View(leave);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


        public ActionResult TakenAction(int Id)
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                bool status = Ls.TakenAction(Id);
                return RedirectToAction("TakenPreview");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult PartialTakenPreview()
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                List<Leaves> leave = Ls.PartialTakenPreview();
                return View(leave);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult PartialTakenAction(int Id)
        {
            CheckAuthentication Ca = new CheckAuthentication(Configuration);
            string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
            if (Check == "Admin")
            {
                LeaveServices Ls = new LeaveServices(Configuration);
                bool status = Ls.PartialTakenAction(Id);
                return RedirectToAction("PartialTakenPreview");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }





        public ActionResult LeaveLedger(int id)
        {
            try
            {
                CheckAuthentication Ca = new CheckAuthentication(Configuration);
                string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
                if (Check == "Admin")
                {
                    EmployeeServices Es = new EmployeeServices(Configuration);
                    List<Employee> AllEmp = Es.GetAllData();
                    ViewBag.AllEmp = AllEmp;
                    if (id == 0)
                    {
                        id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
                        LeaveServices Ls = new LeaveServices(Configuration);
                        List<Leaves> leave = Ls.AllOneEmployeeLeaves(id);
                        IndividualLeave Il = Ls.LeaveBalance(id);
                        ViewBag.totalLeave = Il.LeaveBalance;
                        ViewBag.ImmediateLeave = Il.ImmediateBalance;
                        ViewBag.Name = Es.GetOneEmployee(id).Name;
                        ViewBag.CreditLedger = Ls.AllLeaveCredit(id);
                        return View(leave);
                    }
                    else
                    {
                        LeaveServices Ls = new LeaveServices(Configuration);
                        List<Leaves> leave = Ls.AllOneEmployeeLeaves(id);
                        IndividualLeave Il = Ls.LeaveBalance(id);
                        ViewBag.totalLeave = Il.LeaveBalance;
                        ViewBag.ImmediateLeave = Il.ImmediateBalance;
                        ViewBag.Name = Es.GetOneEmployee(id).Name;
                        ViewBag.CreditLedger = Ls.AllLeaveCredit(id);
                        return View(leave);
                    }

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }




        public ActionResult Lop()
        {
            LeaveServices Ls = new LeaveServices(Configuration);
            List<IndividualLeave> leave = Ls.AllIndividualLeaves();
            return View(leave);
        }

        public ActionResult ReportTaken()
        {
            try
            {
                CheckAuthentication Ca = new CheckAuthentication(Configuration);
                string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
                if (Check == "Admin")
                {
                    LeaveServices Ls = new LeaveServices(Configuration);
                    List<Leaves> data = Ls.AllTakenLeaves();
                    return View(data);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult LeaveSummeryReport()
        {
            try
            {
                CheckAuthentication Ca = new CheckAuthentication(Configuration);
                string Check = Ca.CheckRole(HttpContext.Session.GetInt32("id"));
                if (Check == "Admin")
                {
                    LeaveServices Ls = new LeaveServices(Configuration);
                    List<LeaveSummeryReport> data = Ls.LeaveSummery();
                    return View(data);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: LeaveController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LeaveController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LeaveController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveController/Delete/5
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

