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
    public class ApplicantProfileRepository : BaseADORepository, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach(ApplicantProfilePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                                        ([Id]
                                        ,[Login]
                                        ,[Current_Salary]
                                        ,[Current_Rate]
                                        ,[Currency]
                                        ,[Country_Code]
                                        ,[State_Province_Code]
                                        ,[Street_Address]
                                        ,[City_Town]
                                        ,[Zip_Postal_Code])
                                    VALUES
                                    (@Id,@Login,@Current_Salary,
                                     @Current_Rate,
                                     @Currency,
                                     @Country_Code,
                                     @State_Province_Code,
                                     @Street_Address,
                                     @City_Town,
                                     @Zip_Postal_Code)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"Select * from Applicant_Profiles";
                ApplicantProfilePoco[] ApplicantProfilePoco = new ApplicantProfilePoco[1000];
                int index = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ApplicantProfilePoco item = new ApplicantProfilePoco();
                    item.Id = rdr.GetGuid(0);
                    item.Login = rdr.GetGuid(1);
                    item.CurrentSalary = rdr.GetDecimal(2);
                    item.CurrentRate = rdr.GetDecimal(3);
                    item.Currency = rdr.GetString(4);
                    item.Country = rdr.GetString(5);
                    item.Province = rdr.GetString(6);
                    item.Street = rdr.GetString(7);
                    item.City = rdr.GetString(8);
                    item.PostalCode = rdr.GetString(9);
                    ApplicantProfilePoco[index] = item;
                    index++;


                }

                    return ApplicantProfilePoco.Where(t => t != null).ToList();
            }
        }

        public IList<ApplicantProfilePoco> GetList(Func<ApplicantProfilePoco, bool> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Func<ApplicantProfilePoco, bool> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantProfilePoco item in items)
                {
                    cmd.CommandText = @"delete from Applicant_Profiles where id=@id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantProfilePoco item in items)
                {
                    cmd.CommandText = @"update Applicant_Profiles
                                   set 
                                       [Login]=@Login,
                                       [Current_Salary]=@Current_Salary,
                                       [Current_Rate]=@Current_Rate,
                                       [Currency]=@Currency,
                                       [Country_Code]=@Country_Code,
                                       [State_Province_Code]=@State_Province_Code,
                                       [Street_Address]=@Street_Address,
                                       [City_Town]=@City_Town,
                                       [Zip_Postal_Code]=@Zip_Postal_Code 
                                       where Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);


                    cmd.ExecuteNonQuery();
                }


            }
        }
    }
}
