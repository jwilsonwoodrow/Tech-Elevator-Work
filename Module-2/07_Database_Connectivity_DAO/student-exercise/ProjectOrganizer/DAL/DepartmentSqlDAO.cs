using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class DepartmentSqlDAO : IDepartmentDAO
    {
        private string connectionString;

        // Single Parameter Constructor
        public DepartmentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the departments.
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectDepartments = "select * from department order by department_id";
                SqlCommand command = new SqlCommand(selectDepartments, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                { 
                    Department department = new Department();
                    department.DepartmentID = Convert.ToInt32(reader["department_id"]);
                    department.DepartmentName = Convert.ToString(reader["name"]);
                    departments.Add(department);
                }
                return departments;
            }
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        public int CreateDepartment(Department newDepartment) 
        {
            //try
            //{
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Department (Name) Values (@name); select @@identity", conn);
                    cmd.Parameters.AddWithValue("@name", newDepartment.DepartmentName);
                    int newID = Convert.ToInt32(cmd.ExecuteScalar()); //get new id 
                    return newID;
                }
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine(ex);
            //    return 0;
            //}
        }
        
        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        public bool UpdateDepartment(Department updatedDepartment)
        {
            Department dept = new Department();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Department SET Name = @Name WHERE department_id = @ID", conn);
                    cmd.Parameters.AddWithValue("@Name", updatedDepartment.DepartmentName);
                    cmd.Parameters.AddWithValue("@ID", updatedDepartment.DepartmentID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("eroor");
                throw;
            }
        }

    }
}
