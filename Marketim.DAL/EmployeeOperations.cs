using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketim.Entity;

namespace Marketim.DAL
{
    public class EmployeeOperations : BaseOperation, IDbOperation<Employee>
    {
        public int Delete(int id, int deletedBy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                int affectedRows = 0;

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "SP_DELETE_EMPLOYEE",
                        CommandType = System.Data.CommandType.StoredProcedure
                    })
                    {
                        sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
                        sqlCommand.Parameters.AddWithValue("@DeletedBy", deletedBy);

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

        /// <summary>
        /// Personel listesini verir. Bülent Başyurt
        /// </summary>
        /// <returns></returns>
        public List<Employee> List()
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                List<Employee> employees = new List<Employee>();

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = "SP_LIST_EMPLOOYES";
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }

                        var sdr = sqlCommand.ExecuteReader();

                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                Employee employee = new Employee
                                {
                                    FirstName = sdr["FirstName"].ToString(),
                                    LastName = sdr["LastName"].ToString(),
                                    TCKN = sdr["TCKN"].ToString(),
                                    BirthDate = Convert.ToDateTime(sdr["BirthDate"]),
                                    MobilePhone = sdr["MobilePhone"].ToString(),
                                    EmailAddress = sdr["EmailAddress"].ToString(),
                                    PositionName = sdr["PositionName"].ToString(),
                                    Salary = Convert.ToDecimal(sdr["Salary"]),
                                    RecordStatusName = sdr["RecordStatusName"].ToString()
                                };

                                employees.Add(employee);
                            }
                        }
                        else
                        {
                            sqlConnection.Close();
                            return null;
                        }
                    }
                }
                catch (Exception)
                {
                    sqlConnection.Close();
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return employees;
            }
        }

        public int Save(Employee entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                int affectedRows = 0;

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "SP_INSERT_EMPLOYEE",
                        CommandType = System.Data.CommandType.StoredProcedure
                    })
                    {
                        sqlCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
                        sqlCommand.Parameters.AddWithValue("@LastName", entity.LastName);
                        sqlCommand.Parameters.AddWithValue("@TCKN", entity.TCKN);
                        sqlCommand.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                        sqlCommand.Parameters.AddWithValue("@MobilePhone",
        entity.MobilePhone);
                        sqlCommand.Parameters.AddWithValue("@EmailAddress", entity.EmailAddress);
                        sqlCommand.Parameters.AddWithValue("@PositionId", entity.PositionId);
                        sqlCommand.Parameters.AddWithValue("@Salary", entity.Salary);
                        sqlCommand.Parameters.AddWithValue("@CreatedBy",
        entity.CreatedBy);

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

        public int Update(Employee entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                int affectedRows = 0;

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "SP_UPDATE_EMPLOYEE",
                        CommandType = System.Data.CommandType.StoredProcedure
                    })
                    {
                        sqlCommand.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
                        sqlCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
                        sqlCommand.Parameters.AddWithValue("@LastName", entity.LastName);
                        sqlCommand.Parameters.AddWithValue("@TCKN", entity.TCKN);
                        sqlCommand.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                        sqlCommand.Parameters.AddWithValue("@MobilePhone",
        entity.MobilePhone);
                        sqlCommand.Parameters.AddWithValue("@EmailAddress", entity.EmailAddress);
                        sqlCommand.Parameters.AddWithValue("@PositionId", entity.PositionId);
                        sqlCommand.Parameters.AddWithValue("@Salary", entity.Salary);
                        sqlCommand.Parameters.AddWithValue("@ModifiedBy",
        entity.ModifiedBy);

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
}
