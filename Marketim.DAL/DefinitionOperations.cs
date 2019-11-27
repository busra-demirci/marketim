using Marketim.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Marketim.DAL
{
    public class DefinitionOperations : BaseOperation
    {
        /*
         * Definitions: City, Town, Unit, RecordStatus
         */
        public List<City> GetCities()
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                List<City> cities = new List<City>();

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = "SP_GET_CITIES";
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
                                City city = new City
                                {
                                    CityID = Convert.ToInt32(sdr["CityID"]),
                                    CityName = sdr["CityName"].ToString()
                                };

                                cities.Add(city);
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

                return cities;
            }
        }

        public List<Town> GetTowns(int cityId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                List<Town> towns = new List<Town>();

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = "SP_GET_TOWNS_BY_CITYID";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Connection = sqlConnection;

                        sqlCommand.Parameters.AddWithValue("@cityId", cityId);

                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }

                        var sdr = sqlCommand.ExecuteReader();

                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                Town town = new Town
                                {
                                    TownID = Convert.ToInt32(sdr["TownID"]),
                                    TownName = sdr["TownName"].ToString()
                                };

                                towns.Add(town);
                            }
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

                return towns;
            }
        }

        public List<Unit> GetUnits()
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                List<Unit> units = new List<Unit>();

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("SP_LIST_UNITS", sqlConnection))
                    {
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
                                Unit unit = new Unit
                                {
                                    UnitId = Convert.ToByte(sdr["UnitId"]),
                                    UnitName = sdr["UnitName"].ToString()
                                };

                                units.Add(unit);
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

                return units;
            }
        }

        public List<RecordStatus> GetRecordStatuses()
        {
            using (SqlConnection sqlConnection = new SqlConnection(base.MarketimConnectionString))
            {
                List<RecordStatus> recordStatuses = new List<RecordStatus>();

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("SP_LIST_RECORDSTATUSES", sqlConnection))
                    {
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
                                RecordStatus unit = new RecordStatus
                                {
                                    RecordStatusId = Convert.ToByte(sdr["RecordStatusId"]),
                                    RecordStatusName = sdr["RecordStatusName"].ToString()
                                };

                                recordStatuses.Add(unit);
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
            
                return recordStatuses;
            }
        }
    }
}
