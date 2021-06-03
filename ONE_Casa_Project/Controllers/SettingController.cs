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
    public class SettingController : Controller
    {
        public IConfiguration Configuration { get; }

        public SettingController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET: SettingsController
        public ActionResult JobTitle()
        {
            EmployeeServices EmpService = new EmployeeServices(Configuration);
            List<JobTitles> Job = EmpService.GetJobTitle();

            return View(Job);
        }

        public bool JobTitleUpdate(JobTitles Jt)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.JobTitleUpdate(Jt);
            return status;
        }
        public bool JobTitleDelete(JobTitles Jt)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.JobTitleDelete(Jt);
            return status;
        }
        [HttpPost]
        public ActionResult JobTitleAdd(JobTitles Jt)
        {
            try
            {
                SettingServices St = new SettingServices(Configuration);
                St.JobTitleAdd(Jt);
                return RedirectToAction("JobTitle");
            }
            catch
            {
                return RedirectToAction("JobTitle");
            }
        }


        public ActionResult JoiningLeaveFactor()
        {
            SettingServices St = new SettingServices(Configuration);
            LeaveFactors Data = St.JoiningLeaveFactor();
            return View(Data);
        }


        public bool JoiningLeaveFactorUpdate(LeaveFactors Lf)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.JoiningLeaveFactorUpdate(Lf);
            return status;
        }



        public ActionResult LoyaltyLeave()
        {
            SettingServices St = new SettingServices(Configuration);
            List<LoyaltyLeaveFactors> Data = St.LoyaltyLeaveFactor();
            return View(Data);
        }


        public bool loyaltyLeaveFactorUpdate(int id, int value)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.loyaltyLeaveFactorUpdate(id, value);
            return status;
        }


        public ActionResult MonthlyLeave()
        {
            SettingServices St = new SettingServices(Configuration);
            List<MonthlyLeaves> data = St.MonthlyLeave();
            return View(data);
        }


        public bool MonthlyLeaveUpdate(int id, float value)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.monthlyLeaveUpdate(id, value);
            return status;
        }




        public ActionResult PlannedLeave()
        {
            SettingServices St = new SettingServices(Configuration);
            List<PlannedLeaves> data = St.PlannedLeaves();
            data.ForEach(x =>
            {
                x.Duration = x.Duration * 10;
            });
            return View(data);
        }



        public bool PlannedLeaveUpdate(int id, int value)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.PlannedLeaveUpdate(id, value);
            return status;
        }


        public ActionResult UnplannedLeave()
        {
            SettingServices St = new SettingServices(Configuration);
            List<UnplannedLeaves> data = St.UnplannedLeave();
            data.ForEach(x =>
            {
                x.ImmediateLeaveAvailable = x.ImmediateLeaveAvailable * 10;
                x.DeductionImmediateLeave = x.DeductionImmediateLeave * 10;
                x.DeductionTotalLeave = x.DeductionTotalLeave * 10;
            });
            return View(data);
        }



        public bool UnplannedLeaveUpdate(int id, int value)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.UnplannedLeaveUpdate(id, value);
            return status;
        }


        public ActionResult PublicHoliday()
        {
            SettingServices St = new SettingServices(Configuration);
            List<PublicHolidays> Holiday = St.PublicHoliday();

            return View(Holiday);
        }

        public bool PublicHolidayUpdate(PublicHolidays Ph)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.PublicHolidayUpdate(Ph);
            return status;
        }


        public bool PublicHolidayDelete(int Id)
        {
            SettingServices St = new SettingServices(Configuration);
            bool status = St.PublicHolidayDelete(Id);
            return status;
        }


        public ActionResult PublicHolidayAdd(PublicHolidays Ph)
        {
            try
            {
                SettingServices St = new SettingServices(Configuration);
                St.PublicHolidayAdd(Ph);
                return RedirectToAction("PublicHoliday");
            }
            catch
            {
                return RedirectToAction("PublicHoliday");
            }
        }

        // GET: SettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SettingController/Create
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

        // GET: SettingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SettingController/Edit/5
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

        // GET: SettingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SettingController/Delete/5
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
