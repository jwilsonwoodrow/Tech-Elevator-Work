using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create instances of your object here and call methods.
            HotelReservation reservation1 = new HotelReservation("Jess", 2);
            HotelReservation reservation2 = new HotelReservation("Alex", 1);
            reservation1.AddFees(true, true);
            reservation2.AddFees(false, true);
            string res1String = reservation1.ToString();
            string res2String = reservation2.ToString();
            Console.WriteLine(res1String);
            Console.WriteLine(res2String);


            //public List<HotelReservation> reservations = new List<HotelReservation>();    //This line breaks everything, why?
            using (StreamReader reader = new StreamReader("..\\..\\..\\Data\\HotelInput.csv"))  
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] lineArray = line.Split(",");
                    //reservations.Add(lineArray[0], Int32.Parse(lineArray[1]));
                }

            }


        }
    }
}