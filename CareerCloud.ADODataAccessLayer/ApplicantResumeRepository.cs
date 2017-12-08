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
    public class ApplicantResumeRepository : BaseADORepository, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantResumePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Resumes]
                                        ([Id]
                                        ,[Applicant]
                                        ,[Resume]
                                        ,[Last_Updated])
                                    VALUES
                                    (@Id,@Applicant,@Resume,@Last_Updated)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", item.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                ApplicantResumePoco[] ApplicantResumePoco = new ApplicantResumePoco[1000];
                int index = 0;

                cmd.CommandText = @"select * from [Applicant_Resumes]";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ApplicantResumePoco item = new ApplicantResumePoco();
                    item.Id = rdr.GetGuid(0);
                    item.Applicant = rdr.GetGuid(1);
                    item.Resume = rdr.GetString(2);
                    //item.LastUpdated = rdr.GetDateTime(3);
                    item.LastUpdated = rdr.IsDBNull(3) ? DateTime.MinValue : rdr.GetFieldValue<DateTime>(3);
                    ApplicantResumePoco[index]=item;

                    index++;
                }
                return ApplicantResumePoco.Where(t => t != null).ToList();

            }      
        }

        public IList<ApplicantResumePoco> GetList(Func<ApplicantResumePoco, bool> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Func<ApplicantResumePoco, bool> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantResumePoco item in items)
                {
                    cmd.CommandText = @"delete from Applicant_Resumes where id=@id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantResumePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Resumes]
                                       SET [Id] = @Id,
                                           [Applicant] = @Applicant,
                                           [Resume] = @Resume,
                                           [Last_Updated] = @Last_Updated
                                       WHERE Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", item.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
