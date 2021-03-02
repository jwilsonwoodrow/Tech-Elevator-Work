using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Communities
{
    public class CommunitySqlDao : ICommunityDao
    {
        private readonly string connectionString;

        public CommunitySqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Community> GetAllCommunities()
        {
            // Implement this method to pull in all communities from database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Community> list = new List<Community>();
                connection.Open();
                SqlCommand command = new SqlCommand("select * from communities", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(RowToObject(reader));
                }

                return list;
            }
        }

        public void Save(Community newCommunity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"insert into Communities (name, created, live, latitude, longitude) values (@name, @created, @live, @latitude, @longitude);", connection);
                command.Parameters.AddWithValue("@name", newCommunity.Name);
                command.Parameters.AddWithValue("@created", newCommunity.Created);
                command.Parameters.AddWithValue("@live", newCommunity.IsLive);
                command.Parameters.AddWithValue("@longitude", newCommunity.Longitude);
                command.Parameters.AddWithValue("@latitude", newCommunity.Latitude);
                int rows = command.ExecuteNonQuery();
            }
        }

        private Community RowToObject(SqlDataReader reader)
        {
            Community community = new Community();

            community.Created = Convert.ToDateTime(reader["created"]);
            community.Id = Convert.ToInt64(reader["id"]);
            community.IsLive = Convert.ToBoolean(reader["live"]);
            community.Name = Convert.ToString(reader["name"]);
            community.Longitude = Convert.ToDecimal(reader["longitude"]);
            community.Latitude = Convert.ToDecimal(reader["latitude"]);

            return community;
        }
    }
}