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
    public class CompanyJobRepository : BaseADORepository, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                                    ([Id]
                                    ,[Company]
                                    ,[Profile_Created]
                                    ,[Is_Inactive]
                                    ,[Is_Company_Hidden])
                                    VALUES
                                    (@Id,
                                     @Company,
                                     @Profile_Created,
                                     @Is_Inactive,
                                     @Is_Company_Hidden)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from Company_Jobs";
                CompanyJobPoco[] CompanyJobPoco = new CompanyJobPoco[9999];
                int index = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CompanyJobPoco item = new CompanyJobPoco();
                    item.Id = rdr.GetGuid(0);
                    item.Company = rdr.GetGuid(1);
                    item.ProfileCreated = rdr.GetDateTime(2);
                    item.IsInactive = rdr.GetBoolean(3);
                    item.IsCompanyHidden = rdr.GetBoolean(4);
                    item.TimeStamp = (byte[])rdr["Time_Stamp"];
                    CompanyJobPoco[index] = item;
                    index++;

                }
                return CompanyJobPoco.Where(t => t != null).ToList();
            }
        }

        public IList<CompanyJobPoco> GetList(Func<CompanyJobPoco, bool> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Func<CompanyJobPoco, bool> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            CompanyJobPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault(); throw new NotImplementedException();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"delete from Company_Jobs where id=@id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Jobs]
                                      SET [Id] = @Id,
                                          [Company] = @Company,
                                          [Profile_Created] = @Profile_Created,
                                          [Is_Inactive] = @Is_Inactive,
                                          [Is_Company_Hidden] = @Is_Company_Hidden
                                      WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
