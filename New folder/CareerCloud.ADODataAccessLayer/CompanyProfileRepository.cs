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
    public class CompanyProfileRepository : BaseADORepository, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                                        ([Id]
                                        ,[Registration_Date]
                                        ,[Company_Website]
                                        ,[Contact_Phone]
                                        ,[Contact_Name]
                                        ,[Company_Logo])
                                    VALUES
                                         (@Id
                                          ,@Registration_Date
                                          ,@Company_Website
                                          ,@Contact_Phone
                                          ,@Contact_Name
                                          ,@Company_Logo)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from Company_Profiles";
                CompanyProfilePoco[] CompanyProfilePoco = new CompanyProfilePoco[1000];
                int index = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CompanyProfilePoco item = new CompanyProfilePoco();
                    item.Id = rdr.GetGuid(0);
                    item.RegistrationDate = rdr.GetDateTime(1);
                    item.CompanyWebsite = rdr.IsDBNull(2)? null:rdr.GetString(2);
                    item.ContactPhone = rdr.GetString(3);
                    item.ContactName = rdr.IsDBNull(4)? null:rdr.GetString(4);
                    item.CompanyLogo = rdr.IsDBNull(5) ? null : (byte[])rdr["Company_Logo"];
                    item.TimeStamp=(byte[])rdr["Time_Stamp"];
                    CompanyProfilePoco[index] = item;
                    index++;

                }
                return CompanyProfilePoco.Where(t => t != null).ToList();
            }
        }

        public IList<CompanyProfilePoco> GetList(Func<CompanyProfilePoco, bool> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Func<CompanyProfilePoco, bool> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            CompanyProfilePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"delete from Company_Profiles where id=@id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Profiles]
                                        SET [Id] = @Id,
                                            [Registration_Date] = @Registration_Date,
                                            [Company_Website] = @Company_Website,
                                            [Contact_Phone] = @Contact_Phone,
                                            [Contact_Name] = @Contact_Name,
                                            [Company_Logo] = @Company_Logo
                                        WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
