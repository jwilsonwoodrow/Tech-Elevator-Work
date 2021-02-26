using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teams.DAL;
using Teams.Models;

namespace TeamIntegrationTests
{
    [TestClass]
    public class TeamSqlDAO_Tests
    {
        private string connectionString = @"Server=.\SQLExpress;Database=NFLDB;Trusted_Connection=True;";

        [TestMethod]
        public void GetById_BadId_ExpectNull()
        {
            //arrange: instance new DAO for test
            TeamSqlDAO dao = new TeamSqlDAO(connectionString);

            //act: pass test data into method
            Team actualTeam = dao.GetTeamById(-1);

            //assert: verify expected values
            Assert.IsNull(actualTeam);
        }
    }
}
