using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.IO;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;

namespace EmployeeDB_Tests
{
    [TestClass]
    public class DepartmentSqlDAO_Tests
    {
        const string connectionString = "Server=.\\SQLExpress;Database=EmployeeDB_Test;Trusted_Connection=True;";
        private DepartmentSqlDAO dao;

        [TestInitialize] //called before every test
        public void Arrange()
        {
            SetupDB();
            this.dao = new DepartmentSqlDAO(connectionString);
        }

        [TestMethod]
        public void GetDepartments_Test()
        {
            IList<Department> departments = dao.GetDepartments();

            Assert.IsNotNull(departments);
            Assert.AreEqual(departments.Count, 4);
            Assert.AreEqual(departments[0].DepartmentName, "Department 1");
            Assert.AreEqual(departments[3].DepartmentName, "Department 4");

        }
        
        [TestMethod]
        public void CreateDepartment_Test()
        {
            Department department = new Department();
            department.DepartmentName = "Department 5";
            int newID = dao.CreateDepartment(department);
            Assert.IsNotNull(newID);
            Assert.AreNotEqual(0, newID);
        }

        [TestMethod]
        public void UpdateDepartment_Test()
        {
            Department department = new Department();
            department.DepartmentID = 1;
            department.DepartmentName = "Department 1 mod";
            bool succesful = dao.UpdateDepartment(department);
            Assert.IsTrue(succesful);
            Assert.AreEqual("Department 1 mod", department.DepartmentName);
        }

        private void SetupDB()
        {
            string path = "SetupDB.txt"; //file > properties > Copy to Output Directory = always true
            //read the DB setup script from the text file
            string setupScript = File.ReadAllText(path);

            //create new connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //create new command from text file and execute
                SqlCommand command = new SqlCommand(setupScript, connection);
                command.ExecuteNonQuery();

            }
        }
    }
}
