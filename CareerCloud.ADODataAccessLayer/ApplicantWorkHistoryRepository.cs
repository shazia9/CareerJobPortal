using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository : BaseADORepository, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Work_History]
                                    ([Id],[Applicant],[Company_Name],[Country_Code],[Location],[Job_Title],[Job_Description],[Start_Month]
                                    ,[Start_Year],[End_Month],[End_Year])
                                    VALUES
                                    (@Id,
                                     @Applicant,
                                     @Company_Name,
                                     @Country_Code,
                                     @Location,
                                     @Job_Title,
                                     @Job_Description,
                                     @Start_Month,
                                     @Start_Year,
                                     @End_Month,
                                     @End_Year)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from Applicant_Work_History";
                ApplicantWorkHistoryPoco[] ApplicantWorkHistoryPoco = new ApplicantWorkHistoryPoco[1000];
                int index = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ApplicantWorkHistoryPoco item = new ApplicantWorkHistoryPoco();
                    item.Id = rdr.GetGuid(0);
                    item.Applicant = rdr.GetGuid(1);
                    item.CompanyName = rdr.GetString(2);
                    item.CountryCode = rdr.GetString(3);
                    item.Location = rdr.GetString(4);
                    item.JobTitle = rdr.GetString(5);
                    item.JobDescription = rdr.GetString(6);
                    item.StartMonth = rdr.GetInt16(7);
                    item.StartYear = rdr.GetInt32(8);
                    item.EndMonth = rdr.GetInt16(9);
                    item.EndYear = rdr.GetInt32(10);
                    ApplicantWorkHistoryPoco[index] = item;
                    index++;
                }
                return ApplicantWorkHistoryPoco.Where(t => t != null).ToList();

            }
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Func<ApplicantWorkHistoryPoco, bool> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Func<ApplicantWorkHistoryPoco, bool> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.CommandText = @"delete from Applicant_Work_History where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantWorkHistoryPoco item in items)

                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Work_History]
                                      SET [Id] = @Id,
                                          [Applicant] = @Applicant,
                                          [Company_Name] = @Company_Name,
                                          [Country_Code] = @Country_Code,
                                          [Location] = @Location,
                                          [Job_Title] = @Job_Title,
                                          [Job_Description] = @Job_Description,
                                          [Start_Month] = @Start_Month,
                                          [Start_Year] = @Start_Year,
                                          [End_Month] = @End_Month,
                                          [End_Year] = @End_Year
                                    WHERE Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
