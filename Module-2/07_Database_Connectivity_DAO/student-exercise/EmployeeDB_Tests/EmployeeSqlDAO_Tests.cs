using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace EmployeeDB_Tests
{
    [TestClass]
    public class EmployeeSqlDAO_Tests
    {

        const string connectionString = "Server=.\\SQLExpress;Database=EmployeeDB_Test;Trusted_Connection=True;";
        private EmployeeSqlDAO dao;

        [TestInitialize] //called before every test
        public void Arrange()
        {
            SetupDB();
            this.dao = new EmployeeSqlDAO(connectionString);
        }
        
        [TestMethod]
        public void GetAllEmployees_Test()
        {
            IList<Employee> employees = dao.GetAllEmployees();

            Assert.AreEqual(12, employees.Count);
            Assert.AreEqual("Lambda", employees[10].FirstName);
            Assert.AreEqual("M", employees[6].Gender);
            Assert.AreEqual("Title 11", employees[10].JobTitle);
        }

        [TestMethod]
        public void Search_Test()
        {
            IList<Employee> employees = dao.Search("et", "i");
            Assert.AreEqual(2, employees.Count);
            Assert.AreEqual("Zeta", employees[0].FirstName);
            Assert.AreEqual("Eight", employees[1].LastName);
        }

        [TestMethod]
        public void GetEmployeesWithoutProjects_Test()
        {
            IList<Employee> employees = dao.GetEmployeesWithoutProjects();
            Assert.AreEqual(2, employees.Count);
            Assert.AreEqual("Lambda", employees[0].FirstName);
            Assert.AreEqual("Twelve", employees[1].LastName);
            
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
