using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketim.Entity;

using System.Data;
namespace Marketim.DAL
{
    public class CustomerOperations : IDbOperation<Customer>,BaseOperation
    {
        public int Delete(int id, int deletedBy)
        {
            throw new NotImplementedException();
        }

        public List<Customer> List()
        {

            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                List<Customer> customers = new List<Customer>();
                try
                {




                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = "SP_LIST_CUSTOMERS";
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;


                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }
                        var sdr = sqlCommand.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerId = Convert.ToInt32(sdr["CustomerId"]),
                                    CompanyName = sdr["CompanyName"].ToString(),
                                    ContactName = sdr["ContactName"].ToString()

                                };

                                customers.Add(customer);
                            }

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {

                    sqlConnection.Close();
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return customers;
            }


        }

        public int Save(Customer entity)
        {

            int affectedRows = 0;
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {

                try
                {

                    using (SqlCommand sqlCommand = new SqlCommand


                    {
                        CommandText = "SP_SAVE_CUSTOMERS",
                        Connection = sqlConnection,
                        CommandType = CommandType.StoredProcedure
                    })
                    {

                        sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
                        sqlCommand.Parameters.AddWithValue("@Balance", entity.Balance);
                        sqlCommand.Parameters.AddWithValue("@CompanyName", entity.CompanyName);
                        sqlCommand.Parameters.AddWithValue("@ContactName", entity.ContactName);
                        sqlCommand.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
                        sqlCommand.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
                        sqlCommand.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
                        sqlCommand.Parameters.AddWithValue("@DeletedBy", entity.DeletedBy);
                        sqlCommand.Parameters.AddWithValue("@DeletedDate", entity.DeletedDate);
                        sqlCommand.Parameters.AddWithValue("@EmailAddress", entity.EmailAddress);


                        if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }


                        affectedRows = sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    sqlConnection.Close();
                    return affectedRows;
                }

                finally
                {
                    sqlConnection.Close();

                }
                return affectedRows;
            }


        }

    }

    public int Update(Customer entity)
    {


        int affectedRows = 0;
        using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
        {

            try
            {

                using (SqlCommand sqlCommand = new SqlCommand


                {
                    CommandText = "SP_SAVE_CUSTOMERS",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                })
                {

                    sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
                    sqlCommand.Parameters.AddWithValue("@Balance", entity.Balance);
                    sqlCommand.Parameters.AddWithValue("@CompanyName", entity.CompanyName);
                    sqlCommand.Parameters.AddWithValue("@ContactName", entity.ContactName);
                    sqlCommand.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
                    sqlCommand.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
                    sqlCommand.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
                    sqlCommand.Parameters.AddWithValue("@DeletedBy", entity.DeletedBy);
                    sqlCommand.Parameters.AddWithValue("@DeletedDate", entity.DeletedDate);
                    sqlCommand.Parameters.AddWithValue("@EmailAddress", entity.EmailAddress);


                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }


                    affectedRows = sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return affectedRows;
            }

            finally
            {
                sqlConnection.Close();

            }
            return affectedRows;
        }

    }
}

