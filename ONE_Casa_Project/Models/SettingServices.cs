
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ONE_Casa_Project.Models
{
    public class SettingServices
    {
        string ConnectionString;
        public IConfiguration Configuration { get; }
        public SettingServices(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["DbConnect"];
        }


        public bool JobTitleUpdate(JobTitles Jt)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("update Jobtitle set type=@type where id=@id;", Con);

                Command.Parameters.AddWithValue("@type", Jt.Type);
                Command.Parameters.AddWithValue("@id", Jt.Id);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool JobTitleDelete(JobTitles Jt)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("delete from JobTitle where id=@id;", Con);

                Command.Parameters.AddWithValue("@id", Jt.Id);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void JobTitleAdd(JobTitles Jt)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("insert into JObTitle values(@title,@type)", Con);

                Command.Parameters.AddWithValue("@title", Jt.JobTitle);
                Command.Parameters.AddWithValue("@type", Jt.Type);
                Con.Open();

                Command.ExecuteNonQuery();

            }

        }



    

        public LeaveFactors JoiningLeaveFactor()
        {
            LeaveFactors Lf = new LeaveFactors();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from joiningLeaveFactor", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                Data.Read();

                Lf.From1 = Convert.ToInt32(Data["from1"]);
                Lf.From2 = Convert.ToInt32(Data["from2"]);
                Lf.From3 = Convert.ToInt32(Data["from3"]);
                Lf.From4 = Convert.ToInt32(Data["from4"]);
                Lf.To1 = Convert.ToInt32(Data["to1"]);
                Lf.To2 = Convert.ToInt32(Data["to2"]);
                Lf.To3 = Convert.ToInt32(Data["to3"]);
                Lf.To4 = Convert.ToInt32(Data["to4"]);
                Lf.Factor1 = Convert.ToDouble(Data["leaveFactor1"]);
                Lf.Factor2 = Convert.ToDouble(Data["leaveFactor2"]);
                Lf.Factor3 = Convert.ToDouble(Data["leaveFactor3"]);
                Lf.Factor4 = Convert.ToDouble(Data["leaveFactor4"]);

            }
            return Lf;
        }


        public bool JoiningLeaveFactorUpdate(LeaveFactors Lf)
        {

            if (Lf.From2 - Lf.To1 == 1 && Lf.From3 - Lf.To2 == 1 && Lf.From4 - Lf.To3 == 1)
            {
                
               
            }
            else
            {
                return false;
            }

            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("update joiningLeaveFactor set to1=@to1,to2=@to2,to3=@to3,from2=@from2,from3=@from3,from4=@from4 where from1=@from1", Con);

                Command.Parameters.AddWithValue("@to1", Lf.To1);
                Command.Parameters.AddWithValue("@to2", Lf.To2);
                Command.Parameters.AddWithValue("@to3", Lf.To3);
                Command.Parameters.AddWithValue("@from1", 1);
                Command.Parameters.AddWithValue("@from2", Lf.From2);
                Command.Parameters.AddWithValue("@from3", Lf.From3);
                Command.Parameters.AddWithValue("@from4", Lf.From4);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        public List<LoyaltyLeaveFactors> LoyaltyLeaveFactor()
        {
            List<LoyaltyLeaveFactors> Lf = new List<LoyaltyLeaveFactors>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from loyaltyLeaveFactor", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    LoyaltyLeaveFactors Loyal = new LoyaltyLeaveFactors();
                    Loyal.YearComplete = Convert.ToInt32(Data["yearComplete"]);
                    Loyal.Leave = Convert.ToInt32(Data["leave"]);
                    Lf.Add(Loyal);
                }

            }
            return Lf;
        }


        public bool loyaltyLeaveFactorUpdate(int id, int value)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("update loyaltyLeaveFactor set leave=@leave where yearComplete=@yearComplete;", Con);

                Command.Parameters.AddWithValue("@leave", value);
                Command.Parameters.AddWithValue("@yearComplete", id);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<MonthlyLeaves> MonthlyLeave()
        {
            List<MonthlyLeaves> Ml = new List<MonthlyLeaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from monthlyLeaveFactor", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    MonthlyLeaves Monthly = new MonthlyLeaves();
                    Monthly.From = Convert.ToInt32(Data["from"]);
                    Monthly.To = Convert.ToInt32(Data["to"]);
                    Monthly.Leaves = Convert.ToDouble(Data["leave"]);
                    Ml.Add(Monthly);
                }

            }
            return Ml;
        }

        public bool monthlyLeaveUpdate(int id, float value)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("update monthlyLeaveFactor set leave=@leave where [from]=@from;", Con);

                Command.Parameters.AddWithValue("@leave", value);
                Command.Parameters.AddWithValue("@from", id);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<PlannedLeaves> PlannedLeaves()
        {
            List<PlannedLeaves> Pl = new List<PlannedLeaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from plannedLeave", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    PlannedLeaves Planned = new PlannedLeaves();
                    Planned.Duration = Convert.ToDouble(Data["duration"]);
                    Planned.RequiredTime = Convert.ToInt32(Data["requiredTime"]);
                    Pl.Add(Planned);
                }

            }
            return Pl;
        }

        public bool PlannedLeaveUpdate(int id, int value)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("update plannedLeave set requiredTime=@requiredTime where duration=@duration;", Con);

                Command.Parameters.AddWithValue("@requiredTime", value);
                Command.Parameters.AddWithValue("@duration", (double)id / 10);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<UnplannedLeaves> UnplannedLeave()
        {
            List<UnplannedLeaves> Ul = new List<UnplannedLeaves>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from unplannedLeave", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    UnplannedLeaves Unplanned = new UnplannedLeaves();
                    Unplanned.ImmediateLeaveAvailable = Convert.ToDouble(Data["immediateLeaveAvailable"]);
                    Unplanned.DeductionImmediateLeave = Convert.ToDouble(Data["deductionImmediateLeave"]);
                    Unplanned.DeductionTotalLeave = Convert.ToDouble(Data["deductionTotalLeave"]);
                    Ul.Add(Unplanned);
                }

            }
            return Ul;
        }


        public bool UnplannedLeaveUpdate(int id, int value)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("update unplannedLeave set deductionImmediateLeave=@deductionImmediateLeave where immediateLeaveAvailable=@immediateLeaveAvailable;", Con);

                Command.Parameters.AddWithValue("@deductionImmediateLeave", value);
                Command.Parameters.AddWithValue("@immediateLeaveAvailable", (double)id / 10);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool PublicHolidayUpdate(PublicHolidays Ph)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("update publicHoliday set dates=@dates,holidayName=@holidayName,department=@department where id=@id;", Con);

                Command.Parameters.AddWithValue("@dates", Ph.Dates);
                Command.Parameters.AddWithValue("@id", Ph.Id);
                Command.Parameters.AddWithValue("@holidayName", Ph.HolidayName);
                Command.Parameters.AddWithValue("@department", Ph.Department);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool PublicHolidayDelete(int Id)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("delete from publicHoliday where id=@id;", Con);

                Command.Parameters.AddWithValue("@id", Id);
                Con.Open();

                int Data = Command.ExecuteNonQuery();
                if (Data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void PublicHolidayAdd(PublicHolidays Ph)
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                SqlCommand Command = new SqlCommand("insert into publicHoliday values(@dates,@holidayName,@department)", Con);

                Command.Parameters.AddWithValue("@dates", Ph.Dates);
                Command.Parameters.AddWithValue("@holidayName", Ph.HolidayName);
                Command.Parameters.AddWithValue("@department", Ph.Department);
                Con.Open();

                Command.ExecuteNonQuery();

            }
        }

       public List<PublicHolidays> PublicHoliday()
        {
            List<PublicHolidays> Holiday = new List<PublicHolidays>();
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Select * from publicHoliday", Con);
                Con.Open();

                SqlDataReader Data = Command.ExecuteReader();
                while (Data.Read())
                {
                    PublicHolidays Ph = new PublicHolidays();
                    Ph.Id = Convert.ToInt32(Data["id"]);
                    Ph.Dates = Convert.ToDateTime(Data["dates"]);
                    Ph.HolidayName = Data["holidayName"].ToString();
                    Ph.Department = Data["department"].ToString();
                    Holiday.Add(Ph);
                }
            }
            return Holiday;
        }



    }
}