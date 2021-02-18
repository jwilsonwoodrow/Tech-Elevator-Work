using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    class CitySqlDAO : ICityDAO
    {
        private string ConnectionString;
        private const string SQL_GETCITIESBYCOUNTRY = "select * from City where countrycode = @countryCode";
        public CitySqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<City> GetCitiesByCountry(string countryCode)
        {
            List<City> cities = new List<City>();
            try
            {
                //create db connection
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GETCITIESBYCOUNTRY);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        CityId = Convert.ToInt32(rdr["CityId"]);,

                    }
                }

            }
            catch
            {
                //log the error
                //rethrow so it can be caught up the stack
                throw;
            }
            return cities;
        }
    }
}
