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
    public class SecurityLoginRepository : BaseADORepository, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                                        ([Id]
                                        ,[Login]
                                        ,[Password]
                                        ,[Created_Date]
                                        ,[Password_Update_Date]
                                        ,[Agreement_Accepted_Date]
                                        ,[Is_Locked]
                                        ,[Is_Inactive]
                                        ,[Email_Address]
                                        ,[Phone_Number]
                                        ,[Full_Name]
                                        ,[Force_Change_Password]
                                        ,[Prefferred_Language])
                                        VALUES
                                         (@Id,
                                             @Login,
                                            @Password,
                                            @Created_Date,
                                            @Password_Update_Date,
                                            @Agreement_Accepted_Date,
                                            @Is_Locked,
                                            @Is_Inactive,
                                            @Email_Address,
                                            @Phone_Number,
                                            @Full_Name,
                                            @Force_Change_Password,
                                            @Prefferred_Language)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from Security_Logins";
                SecurityLoginPoco[] SecurityLoginPoco = new SecurityLoginPoco[1000];
                int index = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SecurityLoginPoco item = new SecurityLoginPoco();
                    item.Id = rdr.GetGuid(0);
                    item.Login = rdr.GetString(1);
                    item.Password = rdr.GetString(2);
                    item.Created = rdr.GetDateTime(3);
                    item.PasswordUpdate = rdr.IsDBNull(4)? DateTime.MinValue : rdr.GetDateTime(4);
                    item.AgreementAccepted = rdr.IsDBNull(5)? DateTime.MinValue:rdr.GetDateTime(5);
                    item.IsLocked = rdr.GetBoolean(6);
                    item.IsInactive = rdr.GetBoolean(7);
                    item.EmailAddress = rdr.GetString(8);
                    item.PhoneNumber = rdr.IsDBNull(9)?null:rdr.GetString(9);
                    item.FullName = rdr.GetString(10);
                    item.ForceChangePassword = rdr.GetBoolean(11);
                    item.PrefferredLanguage = rdr.IsDBNull(12)? null:rdr.GetString(12);
                    item.TimeStamp = (byte[])rdr["Time_Stamp"];
                    SecurityLoginPoco[index] = item;
                    index++;

                }
                return SecurityLoginPoco.Where(t => t != null).ToList();

            }
        }

        public IList<SecurityLoginPoco> GetList(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"delete from Security_Logins where id=@id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins]
                                        SET [Id] = @Id,
                                            [Login] = @Login,
                                            [Password] = @Password,
                                            [Created_Date] = @Created_Date,
                                            [Password_Update_Date] = @Password_Update_Date,
                                            [Agreement_Accepted_Date] = @Agreement_Accepted_Date,
                                            [Is_Locked] = @Is_Locked,
                                            [Is_Inactive] = @Is_Inactive,
                                            [Email_Address] = @Email_Address,
                                            [Phone_Number] = @Phone_Number,
                                            [Full_Name] = @Full_Name,
                                            [Force_Change_Password] = @Force_Change_Password,
                                            [Prefferred_Language] = @Prefferred_Language
                                        WHERE Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                    cmd.ExecuteNonQuery();


                }
            }
        }
    }
}
