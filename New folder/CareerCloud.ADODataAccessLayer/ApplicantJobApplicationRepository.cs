using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : BaseADORepository, IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach(ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"Insert into [Applicant_Job_Applications]
                                        ([Id]
                                        ,[Applicant]
                                        ,[Job]
                                        ,[Application_Date])
                                    VALUES
                                        (@Id
                                        ,@Applicant
                                        ,@Job
                                        ,@Application_Date)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);

                    cmd.ExecuteNonQuery();
                }


            }
           
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantJobApplicationPoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from Applicant_Job_Applications";

                ApplicantJobApplicationPoco[] ApplicantJobApplicationPoco = new ApplicantJobApplicationPoco[1000];
                int index = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    ApplicantJobApplicationPoco item = new ApplicantJobApplicationPoco();
                    item.Id = rdr.GetGuid(0);
                    item.Applicant = rdr.GetGuid(1);
                    item.Job = rdr.GetGuid(2);
                    item.ApplicationDate = rdr.GetDateTime(3);
                    item.TimeStamp = (byte[])rdr["Time_Stamp"];
                    ApplicantJobApplicationPoco[index] = item;
                    index++;

                }
                return ApplicantJobApplicationPoco.Where(t => t != null).ToList();
            }
        }

        public IList<ApplicantJobApplicationPoco> GetList(Func<ApplicantJobApplicationPoco, bool> where, params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Func<ApplicantJobApplicationPoco, bool> where, params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            ApplicantJobApplicationPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"delete from Applicant_Job_Applications where id=@id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();


                }
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Job_Applications
                                    SET[Id] = @Id
                                      ,[Applicant] = @Applicant
                                      ,[Job] = @Job
                                     ,[Application_Date] = @Application_Date
                                    WHERE Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
