using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using WorldDB.DAL;
using WorldDB.Models;

namespace WorldDB.IntegrationTests
{
    [TestClass]
    public class CountrySqlDAO_Tests
    {
        const string connectionString = "Server=.\\SQLExpress;Database=World_Test;Trusted_Connection=True;";
        private CountrySqlDAO dao;

        [TestInitialize] //called before every test
        public void Arrange()
        {
            SetupDB();
            this.dao = new CountrySqlDAO(connectionString);
        }


        [TestMethod]
        public void GetCountryByID_Test()
        {
            //arrange: create instance of CountrySqlDAO, establish 'known state' of database
            //SetupDB();
            //CountrySqlDAO dao = new CountrySqlDAO(connectionString);     ... duplicate code moved to Arrange method

            //act: call the GetCountry method
            Country country = dao.GetCountry("USA");

            //assert: make sure we are returned the expected country
            Assert.IsNotNull(country);
            Assert.AreEqual("United States", country.Name);

        }

        [TestMethod]
        public void GetCountriesByContinent_Test()
        {
            //arrange
            //SetupDB();
            //CountrySqlDAO dao = new CountrySqlDAO(connectionString);

            //act: call the GetCountry method
            List<Country> countries = dao.GetCountries("North America");

            //assert: make sure we are returned the expected country
            Assert.IsNotNull(countries);
            Assert.AreEqual(2, countries.Count);
        }

        private void SetupDB()
        {
            string path = "DBSetup.txt"; //file > properties > Copy to Output Directory = always true
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
