using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teams.Models;

namespace Teams.DAL
{
    public class TeamSqlDAO
    {
        private string connectionString;
        public TeamSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<Team> GetAllTeams()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Team> list = new List<Team>();
                connection.Open();
                SqlCommand command = new SqlCommand("select * from teams", connection);
                //no parameters
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(RowToObject(reader));
                }
                return list;
            }
        }

        public Team GetTeamById(int id)
        {
            Team team = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from Team where TeamId = @teamId", connection);
                command.Parameters.AddWithValue("@teamId", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    team = RowToObject(reader);
                }
            }
            return team;
        }

        private Team RowToObject(SqlDataReader reader)
        {
            Team team = new Team();

            team.TeamId = Convert.ToInt32(reader["TeamId"]);
            team.Location = Convert.ToString(reader["Location"]);
            team.TeamName = Convert.ToString(reader["TeamName"]);
            team.Conference = (Conference)Convert.ToInt32(reader["Conference"]);
            team.Division = (Division)Convert.ToInt32(reader["Division"]);
            team.Wins = Convert.ToInt32(reader["TeamId"]);
            team.Losses = Convert.ToInt32(reader["TeamId"]);

            return team;
        }
    }
}
