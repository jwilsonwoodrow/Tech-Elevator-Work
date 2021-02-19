using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class EmployeeSqlDAO : IEmployeeDAO
    {
        private string connectionString;

        // Single Parameter Constructor
        public EmployeeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public IList<Employee> GetAllEmployees()
        {
            List<Employee> EmployeeList = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectString = "select * from employee order by employee_id";
                SqlCommand command = new SqlCommand(selectString, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = RowToObject(reader);
                    EmployeeList.Add(employee);
                }
                return EmployeeList;
            }
        }

        /// <summary>
        /// Find all employees whose names contain the search strings.
        /// Returned employees names must contain *both* first and last names.
        /// </summary>
        /// <remarks>Be sure to use LIKE for proper search matching.</remarks>
        /// <param name="firstname">The string to search for in the first_name field</param>
        /// <param name="lastname">The string to search for in the last_name field</param>
        /// <returns>A list of employees that matches the search.</returns>
        public IList<Employee> Search(string firstname, string lastname)
        {
            List<Employee> Employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string first = "%" + firstname + "%";
                string last = "%" + lastname + "%";
                string selectString =
                    "select * " +
                    "from employee " +
                    "where first_name like @first " +
                    "and last_name like @last " +
                    "order by employee_id";
                SqlCommand command = new SqlCommand(selectString, connection);
                command.Parameters.AddWithValue("@first", first);
                command.Parameters.AddWithValue("@last", last);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = RowToObject(reader);
                    Employees.Add(employee);
                }
                return Employees;
            }
        }

        /// <summary>
        /// Gets a list of employees who are not assigned to any active projects.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            List<Employee> Employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectString =
                    "select* from employee " +
                    "where employee_id not in (select distinct employee_id from project_employee)";
                SqlCommand command = new SqlCommand(selectString, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = RowToObject(reader);
                    Employees.Add(employee);
                }
                return Employees;
            }
        }

        public Employee RowToObject(SqlDataReader reader)
        {
            Employee employee = new Employee();
            employee.EmployeeID = Convert.ToInt32(reader["employee_id"]);
            employee.DepartmentID = Convert.ToInt32(reader["department_id"]);
            employee.FirstName = Convert.ToString(reader["first_name"]);
            employee.LastName = Convert.ToString(reader["last_name"]);
            employee.JobTitle = Convert.ToString(reader["job_title"]);
            employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            employee.Gender = Convert.ToString(reader["gender"]);
            employee.HireDate = Convert.ToDateTime(reader["hire_date"]);
            return employee;
        }
    }
}
