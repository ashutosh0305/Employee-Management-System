
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class LeaveServices
    {
        string ConnectionString;
        public IConfiguration Configuration { get; }
        public LeaveServices(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["DbConnect"];
        }

        public int takenfordash(int i)
        {
            int Result = i;
            int dtaken;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                //SqlCommand Command = new SqlCommand("select Empid from leaves where id=@id LIMIT 1", Con);
                //Command.Parameters.AddWithValue("@id", i);
                //Con.Open();
                //Result = Command.ExecuteNonQuery();

                SqlCommand Command = new SqlCommand("select count(*) from leaves where EmpId=@EmpId and status='Taken'", Con);
                Command.Parameters.AddWithValue("@EmpId", Result);
                Con.Open();

                dtaken = Convert.ToInt32(Command.ExecuteScalar());

            }

            return dtaken;
        }



        public int pendingfordash(int i)
        {
            int Result = i;
            int dpend;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                //SqlCommand Command = new SqlCommand("select Empid from leaves where id=@id LIMIT 1", Con);
                //Command.Parameters.AddWithValue("@id", i);
                //Con.Open();
                //Result = Command.ExecuteNonQuery();

                SqlCommand Command = new SqlCommand("select count(*) from leaves where EmpId=@EmpId and status='Pending'", Con);
                Command.Parameters.AddWithValue("@EmpId", Result);
                Con.Open();

                dpend = Convert.ToInt32(Command.ExecuteScalar());
            }

            return dpend;
        }


        public int pendingforApproved(int i)
        {
            int Result = i;
            int dapprove;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                //SqlCommand Command = new SqlCommand("select Empid from leaves where id=@id LIMIT 1", Con);
                //Command.Parameters.AddWithValue("@id", i);
                //Con.Open();
                //Result = Command.ExecuteNonQuery();

                SqlCommand Command = new SqlCommand("select count(*) from leaves where EmpId=@EmpId and status='Approved'", Con);
                Command.Parameters.AddWithValue("@EmpId", Result);
                Con.Open();

                dapprove = Convert.ToInt32(Command.ExecuteScalar());
            }

            return dapprove;
        }


        public int Rejectfordash(int i)
        {
            int Result = i;
            int dreject;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                //SqlCommand Command = new SqlCommand("select Empid from leaves where id=@id LIMIT 1", Con);
                //Command.Parameters.AddWithValue("@id", i);
                //Con.Open();
                //Result = Command.ExecuteNonQuery();

                SqlCommand Command = new SqlCommand("select count(*) from leaves where EmpId=@EmpId and status='Rejected'", Con);
                Command.Parameters.AddWithValue("@EmpId", Result);
                Con.Open();

                dreject = Convert.ToInt32(Command.ExecuteScalar());
            }

            return dreject;
        }

        public int Canceledfordash(int i)
        {
            int Result = i;
            int dcancel;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                //SqlCommand Command = new SqlCommand("select Empid from leaves where id=@id LIMIT 1", Con);
                //Command.Parameters.AddWithValue("@id", i);
                //Con.Open();
                //Result = Command.ExecuteNonQuery();

                SqlCommand Command = new SqlCommand("select count(*) from leaves where EmpId=@EmpId and status='Cancelled'", Con);
                Command.Parameters.AddWithValue("@EmpId", Result);
                Con.Open();

                dcancel = Convert.ToInt32(Command.ExecuteScalar());
            }

            return dcancel;
        }


















        public int CheckPlannned(DateTime FromDate, DateTime ToDate, TimeSpan FromTime, TimeSpan ToTime, string Status)
        {
            int Result;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command;
                if (Status == "Half Day")
                {
                    Command = new SqlCommand("select requiredTime from PlannedLeave where duration=0.5", Con);
                }
                else
                {
                    int data = Convert.ToInt32(ToDate.Subtract(FromDate).ToString().Split(':')[0].Split('.')[0]) + 1;
                    if (data >= 4)
                    {
                        Command = new SqlCommand("select requiredTime from PlannedLeave where duration=4", Con);
                    }
                    else
                    {
                        Command = new SqlCommand("select requiredTime from PlannedLeave where duration=@date", Con);
                        Command.Parameters.AddWithValue("@date", data);
                    }
                }


                Con.Open();

                Result = Convert.ToInt32(Command.ExecuteScalar());

            }
            return Result;
        }

        public void ApplyLeave(Leaves LeaveData)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                EmployeeServices EmpService = new EmployeeServices(Configuration);
                Employee Emp = EmpService.GetOneEmployee(LeaveData.EmpId);
                SqlCommand Command = new SqlCommand("insert into Leaves values(@EmpId,@EmpName,@fromDate,@toDate,@fromTime,@toTime,@description,@currentDate,@status,@type,@leaveType,@totalLeave,0)", Con);
                Command.Parameters.AddWithValue("@EmpId", LeaveData.EmpId);
                Command.Parameters.AddWithValue("@EmpName", Emp.Name);
                Command.Parameters.AddWithValue("@fromDate", LeaveData.FromDate);
                if (LeaveData.LeaveType == "Half Day")
                {
                    LeaveData.ToDate = LeaveData.FromDate;
                }
                Command.Parameters.AddWithValue("@toDate", LeaveData.ToDate);
                Command.Parameters.AddWithValue("@fromTime", LeaveData.FromTime);
                Command.Parameters.AddWithValue("@toTime", LeaveData.ToTime);
                Command.Parameters.AddWithValue("@description", LeaveData.Description);
                Command.Parameters.AddWithValue("@currentDate", DateTime.Now.Date);
                Command.Parameters.AddWithValue("@status", "Pending");
                Command.Parameters.AddWithValue("@type", LeaveData.Type);
                Command.Parameters.AddWithValue("@leaveType", LeaveData.LeaveType);
                Command.Parameters.AddWithValue("@totalLeave", LeaveData.ToDate.Subtract(LeaveData.FromDate).Days + 1);

                Con.Open();
                try
                {
                    int Result = Command.ExecuteNonQuery();

                }
                catch (Exception e)
                {

                }
            }
        }
        public List<Leaves> AllLeave()
        {
            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves", Con);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    Leaves leave = new Leaves();
                    leave.Id = Convert.ToInt32(data["id"]);
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                    leave.ToDate = Convert.ToDateTime(data["toDate"]);
                    leave.FromTime = (TimeSpan)data["fromTime"];
                    leave.ToTime = (TimeSpan)data["toTime"];
                    leave.Description = data["description"].ToString();
                    leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                    leave.Status = data["status"].ToString();
                    leave.Type = data["type"].ToString();
                    leave.LeaveType = data["leaveType"].ToString();
                    leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                    leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                    Ls.Add(leave);
                }

            }
            return Ls;
        }

        public List<Leaves> findpersonleave(int Id)
        {
            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves where Empid=@id", Con);
                Command.Parameters.AddWithValue("@id", Id);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    Leaves leave = new Leaves();
                    leave.Id = Convert.ToInt32(data["id"]);
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                    leave.ToDate = Convert.ToDateTime(data["toDate"]);
                    leave.FromTime = (TimeSpan)data["fromTime"];
                    leave.ToTime = (TimeSpan)data["toTime"];
                    leave.Description = data["description"].ToString();
                    leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                    leave.Status = data["status"].ToString();
                    leave.Type = data["type"].ToString();
                    leave.LeaveType = data["leaveType"].ToString();
                    leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                    leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                    Ls.Add(leave);
                }

            }
            return Ls;
        }

        public Leaves PendingEdit(int Id)
        {
            Leaves leave = new Leaves();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves where id=@id", Con);
                Command.Parameters.AddWithValue("@id", Id);
                Con.Open();
                var data = Command.ExecuteReader();
                data.Read();
                leave.Id = Convert.ToInt32(data["id"]);
                leave.EmpId = Convert.ToInt32(data["EmpId"]);
                leave.EmpName = data["EmpName"].ToString();
                leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                leave.ToDate = Convert.ToDateTime(data["toDate"]);
                leave.FromTime = (TimeSpan)data["fromTime"];
                leave.ToTime = (TimeSpan)data["toTime"];
                leave.Description = data["description"].ToString();
                leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                leave.Status = data["status"].ToString();
                leave.Type = data["type"].ToString();
                leave.LeaveType = data["leaveType"].ToString();
                leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
            }
            return leave;
        }

        public void PendingEditUpdate(Leaves Ls)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command;
                if (Ls.LeaveType == "Half Day")
                {
                    Command = new SqlCommand("update Leaves set fromDate=@fromDate,status='Pending',toDate=@toDate,fromTime=@fromTime,description=@description, type=@type where id=@id", Con);
                    Command.Parameters.AddWithValue("@fromDate", Ls.FromDate);
                    Command.Parameters.AddWithValue("@fromTime", Ls.FromTime);
                    Command.Parameters.AddWithValue("@description", Ls.Description);
                    Command.Parameters.AddWithValue("@type", Ls.Type);
                    Command.Parameters.AddWithValue("@id", Ls.Id);
                    Command.Parameters.AddWithValue("@toDate", Ls.FromDate);
                }
                else
                {
                    Command = new SqlCommand("update Leaves set fromDate=@fromDate,status='Pending',toDate=@toDate,totalLeave=@totalLeave,description=@description, type=@type where id=@id", Con);
                    Command.Parameters.AddWithValue("@fromDate", Ls.FromDate);
                    Command.Parameters.AddWithValue("@totalLeave", Ls.ToDate.Subtract(Ls.FromDate).Days + 1);
                    Command.Parameters.AddWithValue("@description", Ls.Description);
                    Command.Parameters.AddWithValue("@type", Ls.Type);
                    Command.Parameters.AddWithValue("@id", Ls.Id);
                    Command.Parameters.AddWithValue("@toDate", Ls.ToDate);
                }
                Con.Open();

                Command.ExecuteNonQuery();
            }
        }

        public List<Leaves> AllPendingLeave()
        {
            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves where status='Pending' ", Con);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    Leaves leave = new Leaves();
                    leave.Id = Convert.ToInt32(data["id"]);
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                    leave.ToDate = Convert.ToDateTime(data["toDate"]);
                    leave.FromTime = (TimeSpan)data["fromTime"];
                    leave.ToTime = (TimeSpan)data["toTime"];
                    leave.Description = data["description"].ToString();
                    leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                    leave.Status = data["status"].ToString();
                    leave.Type = data["type"].ToString();
                    leave.LeaveType = data["leaveType"].ToString();
                    leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                    leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                    Ls.Add(leave);
                }

            }
            return Ls;
        }

        public List<Employee> GetRepManagerEmployee(Employee Emp)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from Employee where reportingManager=@reportingManagee", Con);
                Command.Parameters.AddWithValue("@reportingManagee", Emp.Name);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(Data["id"]);
                    employee.Name = Data["name"].ToString();
                    employee.Department = Data["department"].ToString();
                    employee.JobTitle = Data["jobTitle"].ToString();
                    employee.Email = Data["email"].ToString();
                    employee.Mobile = (long)Data["mobile"];
                    employee.ReportingManager = Data["reportingManager"].ToString();
                    employee.Status = Data["status"].ToString();
                    employee.Role = Data["role"].ToString();

                    employee.DateOfJoining = Convert.ToDateTime(Data["dateOfJoining"]);
                    employee.Dob = Convert.ToDateTime(Data["dob"]);
                    employee.Gender = Data["gender"].ToString();
                    employee.InitialImmediate = Convert.ToInt32(Data["initialImmediate"]);
                    employee.InitialLeave = Convert.ToInt32(Data["initialLeave"]);
                    employee.JobRole = Data["jobRole"].ToString();
                    employee.LastWorkingDay = Convert.ToDateTime(Data["lastWorkingDay"]);
                    employee.MarriageAnniversary = Convert.ToDateTime(Data["marriageAnniversary"]);
                    employee.SecondaryApprover = Data["secondaryApprover"].ToString();
                    employees.Add(employee);

                }
            }
            return employees;
        }
        public List<Leaves> GetRepManagerLeaveEmployee(List<Employee> Emps)
        {
            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                string query = "select * from Leaves where EmpId in (";
                string Ids = "";
                int i = 0;
                Emps.ForEach(x =>
                {
                    if (i == 0)
                    {
                        query = query + "@" + x.Id;
                        i++;
                    }
                    else
                    {
                        query = query + ",@" + x.Id;
                    }
                });

                SqlCommand Command = new SqlCommand(query + ") and status='Pending' ", Con);
                Emps.ForEach(x =>
                {
                    Command.Parameters.AddWithValue("@" + x.Id, x.Id);
                });
                Con.Open();
                try
                {
                    var data = Command.ExecuteReader();

                    while (data.Read())
                    {
                        Leaves leave = new Leaves();
                        leave.Id = Convert.ToInt32(data["id"]);
                        leave.EmpId = Convert.ToInt32(data["EmpId"]);
                        leave.EmpName = data["EmpName"].ToString();
                        leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                        leave.ToDate = Convert.ToDateTime(data["toDate"]);
                        leave.FromTime = (TimeSpan)data["fromTime"];
                        leave.ToTime = (TimeSpan)data["toTime"];
                        leave.Description = data["description"].ToString();
                        leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                        leave.Status = data["status"].ToString();
                        leave.Type = data["type"].ToString();
                        leave.LeaveType = data["leaveType"].ToString();
                        leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                        leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                        Ls.Add(leave);
                    }
                }
                catch (Exception e)
                {

                }

            }
            return Ls;
        }

        public bool Approve(int i)
        {
            int Result;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("update Leaves set status='Approved' where id=@id", Con);
                Command.Parameters.AddWithValue("@id", i);
                Con.Open();

                Result = Command.ExecuteNonQuery();
            }
            if (Result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool Cacel(int i)
        {
            int Result;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("update Leaves set status='Cancelled' where id=@id", Con);
                Command.Parameters.AddWithValue("@id", i);
                Con.Open();

                Result = Command.ExecuteNonQuery();
            }
            if (Result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Reject(int i)
        {
            int Result;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("update Leaves set status='Rejected' where id=@id", Con);
                Command.Parameters.AddWithValue("@id", i);
                Con.Open();

                Result = Command.ExecuteNonQuery();
            }
            if (Result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Leaves> TakenPreview()
        {
            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves where status='Approved' or status='Partial Taken' ", Con);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    Leaves leave = new Leaves();
                    leave.Id = Convert.ToInt32(data["id"]);
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                    leave.ToDate = Convert.ToDateTime(data["toDate"]);
                    leave.FromTime = (TimeSpan)data["fromTime"];
                    leave.ToTime = (TimeSpan)data["toTime"];
                    leave.Description = data["description"].ToString();
                    leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                    leave.Status = data["status"].ToString();
                    leave.Type = data["type"].ToString();
                    leave.LeaveType = data["leaveType"].ToString();
                    leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                    leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                    Ls.Add(leave);
                }

            }
            List<Leaves> leaveTemp = new List<Leaves>();
            Ls.ForEach(x =>
            {
                //DateTime date = DateTime.Now;
                int temp = DateTime.Now.Date.Subtract(x.FromDate).Days;
                if (temp == x.TakenLeave)
                {
                    leaveTemp.Add(x);
                }
            });
            return leaveTemp;
        }

        public bool TakenAction(int id)
        {
            string status = "Partial Taken";
            using (SqlConnection Conc1 = new SqlConnection(ConnectionString))
            {
                SqlCommand Commands1 = new SqlCommand("select takenLeave from leaves where id=@ids", Conc1);
                SqlCommand Commands2 = new SqlCommand("select totalLeave from leaves where id=@ids", Conc1);
                Commands1.Parameters.AddWithValue("@ids", id);
                Commands2.Parameters.AddWithValue("@ids", id);

                Conc1.Open();

                int temp1 = Convert.ToInt32(Commands1.ExecuteScalar());
                int temp2 = Convert.ToInt32(Commands2.ExecuteScalar());
                if ((temp1 + 1) == temp2)
                {
                    status = "Taken";
                }
            }
            int Result, temp;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("update Leaves set status=@status , takenLeave=@takenLeave where id=@id", Con);
                Command.Parameters.AddWithValue("@id", id);
                using (SqlConnection Conc = new SqlConnection(ConnectionString))
                {
                    SqlCommand Commands = new SqlCommand("select takenLeave from leaves where id=@ids", Conc);
                    Commands.Parameters.AddWithValue("@ids", id);
                    Conc.Open();

                    temp = Convert.ToInt32(Commands.ExecuteScalar());
                }
                Command.Parameters.AddWithValue("@takenLeave", temp + 1);
                Command.Parameters.AddWithValue("@status", status);
                Con.Open();

                Result = Command.ExecuteNonQuery();
            }
            if (Result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Leaves> PartialTakenPreview()
        {
            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves where status='Partial Taken' or status='Taken' ", Con);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    Leaves leave = new Leaves();
                    leave.Id = Convert.ToInt32(data["id"]);
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                    leave.ToDate = Convert.ToDateTime(data["toDate"]);
                    leave.FromTime = (TimeSpan)data["fromTime"];
                    leave.ToTime = (TimeSpan)data["toTime"];
                    leave.Description = data["description"].ToString();
                    leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                    leave.Status = data["status"].ToString();
                    leave.Type = data["type"].ToString();
                    leave.LeaveType = data["leaveType"].ToString();
                    leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                    leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                    Ls.Add(leave);
                }

            }
            List<Leaves> leaveTemp = new List<Leaves>();
            Ls.ForEach(x =>
            {
                //DateTime date = DateTime.Now;
                int temp = DateTime.Now.Date.Subtract(x.FromDate).Days;
                int temp2 = DateTime.Now.Date.Subtract(x.ToDate).Days;
                if ((temp + 1) == x.TakenLeave)
                {
                    if (temp2 > 0)
                    {

                    }
                    else
                    {
                        leaveTemp.Add(x);
                    }
                    //leaveTemp.Add(x);
                }
            });
            return leaveTemp;
        }

        public bool PartialTakenAction(int id)
        {

            int Result, temp;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("update Leaves set status='Approved',takenLeave=@takenLeave where id=@id", Con);
                Command.Parameters.AddWithValue("@id", id);
                using (SqlConnection Conc = new SqlConnection(ConnectionString))
                {
                    SqlCommand Commands = new SqlCommand("select takenLeave from leaves where id=@ids", Conc);
                    Commands.Parameters.AddWithValue("@ids", id);
                    Conc.Open();

                    temp = Convert.ToInt32(Commands.ExecuteScalar());
                }
                Command.Parameters.AddWithValue("@takenLeave", temp - 1);
                Con.Open();

                Result = Command.ExecuteNonQuery();
            }
            if (Result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public List<LeaveCreditModel> AllLeaveCredit(int id)
        {
            List<LeaveCreditModel> Ls = new List<LeaveCreditModel>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from LeaveCreditLedger where EmpId=@id", Con);
                Command.Parameters.AddWithValue("@id", id);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    LeaveCreditModel leave = new LeaveCreditModel();
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.Type = data["type"].ToString();
                    leave.TotalLeave = Convert.ToDouble(data["totalLeave"]);
                    leave.ImmediateLeave = Convert.ToDouble(data["immediateBalance"]);
                    leave.Amount = Convert.ToDouble(data["amount"]);
                    leave.OnDate = Convert.ToDateTime(data["onDate"]);
                    leave.Note = data["note"].ToString();
                    Ls.Add(leave);
                }

            }
            return Ls;
        }






        public List<Leaves> AllOneEmployeeLeaves(int id)
        {

            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves where EmpID=@id ", Con);
                Command.Parameters.AddWithValue("@id", id);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    Leaves leave = new Leaves();
                    leave.Id = Convert.ToInt32(data["id"]);
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                    leave.ToDate = Convert.ToDateTime(data["toDate"]);
                    leave.FromTime = (TimeSpan)data["fromTime"];
                    leave.ToTime = (TimeSpan)data["toTime"];
                    leave.Description = data["description"].ToString();
                    leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                    leave.Status = data["status"].ToString();
                    leave.Type = data["type"].ToString();
                    leave.LeaveType = data["leaveType"].ToString();
                    leave.TakenLeave = Convert.ToInt32(data["takeLeave"]);
                    leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                    Ls.Add(leave);
                }

            }
            return Ls;
        }



        public IndividualLeave LeaveBalance(int id)
        {
            IndividualLeave Ls = new IndividualLeave();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from individualLeave where EmpID=@id ", Con);
                Command.Parameters.AddWithValue("@id", id);
                Con.Open();
                var data = Command.ExecuteReader();
                data.Read();
                Ls.EmpId = Convert.ToInt32(data["EmpId"]);
                Ls.EmpName = data["EmpName"].ToString();
                Ls.LeaveBalance = Convert.ToDouble(data["leaveBalance"]);
                Ls.ImmediateBalance = Convert.ToDouble(data["immediateLeave"]);


            }
            return Ls;
        }





        public List<Leaves> AllTakenLeaves()
        {
            List<Leaves> Ls = new List<Leaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from Leaves where status='Taken' ", Con);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    Leaves leave = new Leaves();
                    leave.Id = Convert.ToInt32(data["id"]);
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.FromDate = Convert.ToDateTime(data["fromDate"]);
                    leave.ToDate = Convert.ToDateTime(data["toDate"]);
                    leave.FromTime = (TimeSpan)data["fromTime"];
                    leave.ToTime = (TimeSpan)data["toTime"];
                    leave.Description = data["description"].ToString();
                    leave.CurrentDate = Convert.ToDateTime(data["currentDate"]);
                    leave.Status = data["status"].ToString();
                    leave.Type = data["type"].ToString();
                    leave.LeaveType = data["leaveType"].ToString();
                    leave.TakenLeave = Convert.ToInt32(data["takenLeave"]);
                    leave.TotalLeave = Convert.ToInt32(data["totalLeave"]);
                    Ls.Add(leave);
                }

            }
            return Ls;
        }





        public List<IndividualLeave> AllIndividualLeaves()
        {
            List<IndividualLeave> Ls = new List<IndividualLeave>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from individualLeave", Con);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {
                    IndividualLeave leave = new IndividualLeave();
                    leave.EmpId = Convert.ToInt32(data["EmpId"]);
                    leave.EmpName = data["EmpName"].ToString();
                    leave.LeaveBalance = Convert.ToDouble(data["leaveBalance"]);
                    leave.ImmediateBalance = Convert.ToDouble(data["immediateLeave"]);
                    Ls.Add(leave);
                }

            }
            return Ls;
        }


        public List<LeaveSummeryReport> LeaveSummery()
        {
            List<LeaveSummeryReport> Ls = new List<LeaveSummeryReport>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("select * from LeaveSummeryReport; ", Con);
                Con.Open();
                var data = Command.ExecuteReader();
                while (data.Read())
                {


                    LeaveSummeryReport l = new LeaveSummeryReport();
                    l.id = Convert.ToInt32(data["id"]);
                    l.name = data["name"].ToString();
                    l.department = data["department"].ToString();
                    l.InitialImmediateInstance = Convert.ToInt32(data["InitialImmediateInstance"]);
                    l.AddedImmediateinThisMonth = Convert.ToInt32(data["AddedImmediateinThisMonth"]);
                    l.OpeningImmediateInstance = Convert.ToInt32(data["OpeningImmediateInstance"]);
                    l.MonthlyLeaveFactor = Convert.ToInt32(data["MonthlyLeaveFactor"]);
                    l.JoiningLeaveFactor = Convert.ToInt32(data["JoiningLeaveFactor"]);
                    l.ImmediateLeave = Convert.ToInt32(data["ImmediateLeave"]);
                    l.role = data["role"].ToString();
                    Ls.Add(l);


                }





            }
            return Ls;
        }

    }
}
