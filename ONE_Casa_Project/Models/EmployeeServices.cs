using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Configuration;
namespace ONE_Casa_Project.Models
{
    public class EmployeeServices
    {
        string ConnectionString;
        public IConfiguration Configuration { get; }
        public EmployeeServices(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["DbConnect"];
        }


        public string findnameservice(int i)
        {
            int Result = i;
          string dapprove;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                //SqlCommand Command = new SqlCommand("select Empid from leaves where id=@id LIMIT 1", Con);
                //Command.Parameters.AddWithValue("@id", i);
                //Con.Open();
                //Result = Command.ExecuteNonQuery();

                SqlCommand Command = new SqlCommand("select name from Employee where id=@EmpId ", Con);
                Command.Parameters.AddWithValue("@EmpId", Result);
                Con.Open();

                dapprove =Command.ExecuteScalar().ToString();
            }

            return dapprove;
        }







        public List<Employee> GetAllData()
        {
            List<Employee> Emp = new List<Employee>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from Employee", Con);
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
                    Emp.Add(employee);

                }
                return Emp;
            }
        }

        public List<JobTitles> GetJobTitle()
        {
            List<JobTitles> jobTitle = new List<JobTitles>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from JobTitle", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    JobTitles jt = new JobTitles();
                    jt.Id = Convert.ToInt32(Data["id"]);
                    jt.JobTitle = Data["jobTitle"].ToString();
                    jt.Type = Data["type"].ToString();
                    jobTitle.Add(jt);
                }
            }
            return jobTitle;
        }

        public List<Departments> getDepartment()
        {
            List<Departments> departmets = new List<Departments>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from Department", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    Departments department = new Departments();
                    department.Id = Convert.ToInt32(Data["id"]);
                    department.DepartmentName = Data["DepartmentName"].ToString();
                    departmets.Add(department);
                }
            }
            return departmets;
        }


        public void SetNewEmployee(Employee Emp)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("insert into Employee values(@name,@dob,@gender,@marriageAnniversary,@dateOfJoining,@department,@jobTitle,@jobRole," +
                    "@secondaryApprover,@email, @mobile, @reportingManager, @initialLeave, @initialImmediate, @status,@lastWorkingDay, @role)", Con);

                Command.Parameters.AddWithValue("@name", Emp.Name);
                Command.Parameters.AddWithValue("@dob", Emp.Dob.Date);
                Command.Parameters.AddWithValue("@gender", Emp.Gender);
                if (Emp.MarriageAnniversary == null) { Emp.MarriageAnniversary = DateTime.Now; }
                Command.Parameters.AddWithValue("@marriageAnniversary", Emp.MarriageAnniversary);
                Command.Parameters.AddWithValue("@dateOfJoining", Emp.DateOfJoining.Date);
                Command.Parameters.AddWithValue("@department", Emp.Department);
                Command.Parameters.AddWithValue("@jobTitle", Emp.JobTitle);
                if (Emp.JobRole == null) { Emp.JobRole = "Empty"; }
                Command.Parameters.AddWithValue("@jobRole", Emp.JobRole);
                if (Emp.SecondaryApprover == null) { Emp.SecondaryApprover = "Empty"; }
                Command.Parameters.AddWithValue("@secondaryApprover", Emp.SecondaryApprover);
                Command.Parameters.AddWithValue("@email", Emp.Email);
                Command.Parameters.AddWithValue("@mobile", Emp.Mobile);
                Command.Parameters.AddWithValue("@reportingManager", Emp.ReportingManager);
                Command.Parameters.AddWithValue("@initialLeave", Emp.InitialLeave);
                Command.Parameters.AddWithValue("@initialImmediate", Emp.InitialImmediate);
                Command.Parameters.AddWithValue("@status", Emp.Status);
                if (Emp.LastWorkingDay == null) { Emp.LastWorkingDay = DateTime.Now; }
                Command.Parameters.AddWithValue("@lastWorkingDay", Emp.LastWorkingDay);
                Command.Parameters.AddWithValue("@role", Emp.Role);
                Con.Open();
                try
                {
                    int Data = Command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    var ae = e;
                }
            }
        }

        public Employee GetOneEmployee(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                
                SqlCommand Command = new SqlCommand("Select * from Employee where id=@idd", Con);
                Command.Parameters.AddWithValue("@idd", id);
                Con.Open();
                SqlDataReader Data = Command.ExecuteReader();
                Data.Read();
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

            }
            return employee;
        }

        public void UpdateEmployee(Employee Emp)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("update Employee set name=@name,dob=@dob,gender=@gender,marriageAnniversary=@marriageAnniversary,dateOfJoining=@dateOfJoining,department=@department,jobTitle=@jobTitle,jobRole=@jobRole," +
                    "secondaryApprover=@secondaryApprover,email=@email,mobile= @mobile, reportingManager=@reportingManager,initialLeave= @initialLeave, initialImmediate=@initialImmediate, status=@status,lastWorkingDay=@lastWorkingDay,role= @role where id=@id", Con);
                Command.Parameters.AddWithValue("@id", Emp.Id);
                Command.Parameters.AddWithValue("@name", Emp.Name);
                Command.Parameters.AddWithValue("@dob", Emp.Dob.Date);
                Command.Parameters.AddWithValue("@gender", Emp.Gender);
                if (Emp.MarriageAnniversary == null) { Emp.MarriageAnniversary = DateTime.Now; }
                Command.Parameters.AddWithValue("@marriageAnniversary", Emp.MarriageAnniversary);
                Command.Parameters.AddWithValue("@dateOfJoining", Emp.DateOfJoining.Date);
                Command.Parameters.AddWithValue("@department", Emp.Department);
                Command.Parameters.AddWithValue("@jobTitle", Emp.JobTitle);
                if (Emp.JobRole == null) { Emp.JobRole = "Empty"; }
                Command.Parameters.AddWithValue("@jobRole", Emp.JobRole);
                if (Emp.SecondaryApprover == null) { Emp.SecondaryApprover = "Empty"; }
                Command.Parameters.AddWithValue("@secondaryApprover", Emp.SecondaryApprover);
                Command.Parameters.AddWithValue("@email", Emp.Email);
                Command.Parameters.AddWithValue("@mobile", Emp.Mobile);
                Command.Parameters.AddWithValue("@reportingManager", Emp.ReportingManager);
                Command.Parameters.AddWithValue("@initialLeave", Emp.InitialLeave);
                Command.Parameters.AddWithValue("@initialImmediate", Emp.InitialImmediate);
                Command.Parameters.AddWithValue("@status", Emp.Status);
                if (Emp.LastWorkingDay == null) { Emp.LastWorkingDay = DateTime.Now; }
                Command.Parameters.AddWithValue("@lastWorkingDay", Emp.LastWorkingDay);
                Command.Parameters.AddWithValue("@role", Emp.Role);
                Con.Open();
                try
                {
                    int Data = Command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    var ae = e;
                }
            }
        }


        public List<Employee> Getemployee(string fname)
        {
            List<Employee> Emp = new List<Employee>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from Employee where name like '"+fname+"%'", Con);
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
                    Emp.Add(employee);

                }
                return Emp;
            }
        }





        public List<Employee> isactive()
        {
            string fname = "Active";
            List<Employee> Emp = new List<Employee>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from Employee where status=@statuss" , Con);
                Command.Parameters.AddWithValue("@statuss", fname);
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
                    Emp.Add(employee);

                }
                return Emp;
            }
        }







        public List<Employee> isinactive()
        {
            string fname = "InActive";
            List<Employee> Emp = new List<Employee>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from Employee where status=@statuss", Con);
                Command.Parameters.AddWithValue("@statuss", fname);
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
                    Emp.Add(employee);

                }
                return Emp;
            }
        }




    }
}
