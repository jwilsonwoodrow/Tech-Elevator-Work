using BankTellerExercise;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment;

namespace BankTellerExerciseTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void AddFees_Test()
        {
            //arrange 
            HotelReservation testRes = new HotelReservation("Alpha", 5);
            HotelReservation testRes1 = new HotelReservation("Beta", 2);
            HotelReservation testRes2 = new HotelReservation("Gamma", 0);


            //act
            testRes.AddFees(true, false);
            testRes1.AddFees(true, true);
            testRes2.AddFees(false, false);

            //assert
            Assert.AreEqual(testRes.EstimatedTotal, 312.94M);
            Assert.AreEqual(testRes1.EstimatedTotal, 180.95M);
            Assert.AreEqual(testRes2.EstimatedTotal, 0.00M);
        }
        
        //ran out of time to test regular estimate calculation
    }
}
