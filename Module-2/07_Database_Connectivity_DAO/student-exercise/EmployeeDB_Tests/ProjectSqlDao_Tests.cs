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
    public class ProjectSqlDAO_Tests
    {
        const string connectionString = "Server=.\\SQLExpress;Database=EmployeeDB_Test;Trusted_Connection=True;";
        private ProjectSqlDAO dao;
        
        [TestInitialize] //called before every test
        public void Arrange()
        {
            SetupDB();
            this.dao = new ProjectSqlDAO(connectionString);
        }

        [TestMethod]
        public void GetAllProjects_Test()
        {
            IList<Project> projects = dao.GetAllProjects();
            Assert.AreEqual(6, projects.Count);
            Assert.AreEqual("Project 1", projects[0].ProjectName);
            Assert.AreEqual("Project 6", projects[5].ProjectName);
            Assert.AreEqual("3/3/2000 12:00:00 AM", Convert.ToString(projects[2].StartDate)); 
            Assert.AreEqual("5/5/2001 12:00:00 AM", Convert.ToString(projects[4].EndDate));
        }

        [TestMethod]
        public void AssignEmployeeToProject_Test()
        {
            bool success = dao.AssignEmployeeToProject(1, 3);  //TODO: is this all I need?
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void RemoveEmployeeFromProject_Test()
        { 
            bool success = dao.RemoveEmployeeFromProject(1, 1); 
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void CreateProject_Test()
        {
            Project project = new Project();
            project.ProjectName = "Test Project";
            project.StartDate = new DateTime(2000, 07, 07);
            project.EndDate = new DateTime(2000, 07, 07);
            int newID = dao.CreateProject(project);
            Assert.IsNotNull(newID);
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
