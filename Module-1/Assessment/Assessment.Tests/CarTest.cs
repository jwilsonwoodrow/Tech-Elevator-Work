using System.ComponentModel.DataAnnotations;

using Assessment.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.Tests
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        [DataRow(2021,"Jeep",false,false, DisplayName = "a 2021")]
        [DataRow(2017, "Jeep", false, true, DisplayName = "a 2017")]
        [DataRow(2015, "Jeep", false, true, DisplayName = "a 2015")]
        [DataRow(1990, "Jeep", false, false, DisplayName = "a 1990")]
        [DataRow(1960, "Jeep", true, false, DisplayName = "a 1960")]
        public void shouldHaveECheck(int curYear, string curMake, bool curClassic,bool expectedResult)
        {
            Car myCar = new Car(curYear,curMake,curClassic);
            bool actualRequiresECheck = myCar.needsECheck(2021);

            Assert.AreEqual(expectedResult, actualRequiresECheck);

        }

        [TestMethod]
        [DataRow(2021, "Jeep", false, 0, DisplayName = "a 2021")]
        [DataRow(2020, "Jeep", false, 1, DisplayName = "a 2020")]
        [DataRow(2019, "Jeep", false, 2, DisplayName = "a 2019")]
        [DataRow(2000, "Jeep", false, 21, DisplayName = "a 2000")]
        public void shouldHaveCorrectAge(int curYear, string curMake, bool curIsClassic, int expectedAge) {
            Car myCar = new Car(curYear, curMake, curIsClassic);

            Assert.AreEqual(expectedAge, myCar.Age);
        }
    }
}
