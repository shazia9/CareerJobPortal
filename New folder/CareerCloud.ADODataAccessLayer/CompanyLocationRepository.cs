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
    public class CompanyLocationRepository : BaseADORepository, IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyLocationPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Locations]
                                    ([Id]
                                    ,[Company]
                                    ,[Country_Code]
                                    ,[State_Province_Code]
                                    ,[Street_Address]
                                    ,[City_Town]
                                    ,[Zip_Postal_Code])
                                    VALUES
                                     (@Id,
                                        @Company,
                                        @Country_Code,
                                        @State_Province_Code,
                                        @Street_Address,
                                        @City_Town,
                                        @Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from Company_Locations";
                CompanyLocationPoco[] CompanyLocationPoco = new CompanyLocationPoco[1000];
                int index = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CompanyLocationPoco item = new CompanyLocationPoco();
                    item.Id = rdr.GetGuid(0);
                    item.Company = rdr.GetGuid(1);
                    item.CountryCode = rdr.GetString(2);
                    item.Province = rdr.GetString(3);
                    item.Street = rdr.GetString(4);
                    //item.City = rdr.GetString(5);
                    item.City = rdr.IsDBNull(5) ? null : rdr.GetString(5);
                    //item.PostalCode = rdr.GetString(6);
                    item.PostalCode = rdr.IsDBNull(6) ? null:rdr.GetString(6);
                    CompanyLocationPoco[index] = item;
                    index++;

                }
                return CompanyLocationPoco.Where(t => t != null).ToList();
            }
        }

        public IList<CompanyLocationPoco> GetList(Func<CompanyLocationPoco, bool> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Func<CompanyLocationPoco, bool> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            CompanyLocationPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyLocationPoco item in items)
                {
                    cmd.CommandText = @"delete from Company_Locations where id=@id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyLocationPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Locations]
                                    SET [Id] = @Id,
                                        [Company] = @Company,
                                        [Country_Code] = @Country_Code,
                                        [State_Province_Code] = @State_Province_Code,
                                        [Street_Address] = @Street_Address,
                                        [City_Town] = @City_Town,
                                        [Zip_Postal_Code] = @Zip_Postal_Code
                                    WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
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
