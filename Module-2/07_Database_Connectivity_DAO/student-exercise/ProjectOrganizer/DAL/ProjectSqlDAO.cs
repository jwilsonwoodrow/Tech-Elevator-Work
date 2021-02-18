using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class ProjectSqlDAO : IProjectDAO
    {
        private string connectionString;

        // Single Parameter Constructor
        public ProjectSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {
            List<Project> Projects = new List<Project>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectString = "select * from project order by project_id";
                SqlCommand command = new SqlCommand(selectString, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Project project = RowToObject(reader);
                    Projects.Add(project);
                }
                return Projects;
            }
        }


        /// <summary>
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertString = "insert into project_employee (project_id, employee_id) Values (@projectID, @employeeID)";
                    SqlCommand command = new SqlCommand(insertString, connection);
                    command.Parameters.AddWithValue("@projectID", projectId);
                    command.Parameters.AddWithValue("@employeeID", employeeId);
                    int rowsAltered = Convert.ToInt32(command.ExecuteNonQuery());
                    if (rowsAltered > 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertString = "delete from project_employee where project_id = @projectID and employee_id = @employeeID";
                SqlCommand command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@projectID", projectId);
                command.Parameters.AddWithValue("@employeeID", employeeId);
                int rowsAltered = Convert.ToInt32(command.ExecuteNonQuery());
                if (rowsAltered > 0)
                {
                    return true;
                }
                else return false;
            }
        }


        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Project (name, from_date, to_date) Values (@name, @fromDate, @toDate); select @@identity", conn);
                cmd.Parameters.AddWithValue("@name", newProject.ProjectName);
                cmd.Parameters.AddWithValue("@fromDate", newProject.StartDate);
                cmd.Parameters.AddWithValue("@toDate", newProject.EndDate);
                int newID = Convert.ToInt32(cmd.ExecuteScalar()); //get new id 
                return newID;
            }
        }

        public Project RowToObject(SqlDataReader reader)
        {
            Project project = new Project();
            project.ProjectID = Convert.ToInt32(reader["project_id"]);
            project.ProjectName = Convert.ToString(reader["name"]);
                project.StartDate = Convert.ToDateTime(reader["from_date"]);
            project.EndDate = Convert.ToDateTime(reader["to_date"]);
            return project;
        }
    }
}
