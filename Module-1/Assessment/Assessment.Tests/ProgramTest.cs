using System;
using System.Collections.Generic;
using System.Text;

using Assessment.Models;
using Assessment;


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void shouldParseToCar() {
            List<string> carText = new List<string>() {
                "1965,Ford Mustang,true",
                "2019,Subaru,false",
                "1920,Baker Electric,true",
                "1970,Pontiac GTO,true",
                "2018,Toyota Camry,false",
            };

            List<Car> parsedCars = Program.parseLinesToCar(carText);


            Assert.AreEqual(5,parsedCars.Count);
            Assert.AreEqual("Ford Mustang", parsedCars[0].Make);
            Assert.AreEqual(1965, parsedCars[0].Year);
            Assert.AreEqual(true, parsedCars[0].IsClassicCar);
        }
    }
}
