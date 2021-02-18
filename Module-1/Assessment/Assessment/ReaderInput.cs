using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment
{
    public class ReaderInput
    {
        public Dictionary<String, int> reservations = new Dictionary<string, int>();
        public Dictionary<String, int> ReadData()
        {
            using (StreamReader reader = new StreamReader("..\\..\\..\\Data\\HotelInput.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] lineArray = line.Split(",");
                    reservations.Add(lineArray[0], Int32.Parse(lineArray[1]));
                    return reservations;
                    
                }
            }
        }
    }
}
