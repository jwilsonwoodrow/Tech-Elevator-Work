using System;
using System.Collections.Generic;
using System.IO;

using Assessment.Models;

namespace Assessment
{
    public class Program
    {
        private const string PATH_TO_FILE = "../../../Data/CarInput.csv";


        static void Main(string[] args)
        {
            Car myJeep = new Car(2021,"Jeep", false);
            Car myInfiniti = new Car(2013,"Infiniti",false);

            Console.WriteLine($"Does {myJeep.ToString()} need an E-Check: {myJeep.needsECheck(2021)}");
            Console.WriteLine($"Does {myInfiniti.ToString()} need an E-Check: {myInfiniti.needsECheck(2021)}");

            List<string> linesFromFile = Program.readFile(PATH_TO_FILE);

            List<Car> cars = new List<Car>();
            int sumAge = 0;
            cars = Program.parseLinesToCar(linesFromFile);
            foreach (Car curCar in cars) {
                Console.WriteLine(curCar.ToString());
                sumAge = sumAge + curCar.Age;
            }

            Console.WriteLine($"\n\nSum of car ages is {sumAge}");

        }


        public static List<Car> parseLinesToCar(List<string> linesofText) {
            List<Car> cars = new List<Car>();
            foreach (string curLine in linesofText)
            {
                string[] fields = curLine.Split(",");
                Car curCar = new Car(int.Parse(fields[0]), fields[1], bool.Parse(fields[2]));
                cars.Add(curCar);
            }

            return cars;
        }

        private static List<string> readFile (string pathToFile) {
            List<string> inputFileLines = new List<string>();

            using (StreamReader reader = new StreamReader(pathToFile))
            {
                while (!reader.EndOfStream)
                {
                    string curLine = reader.ReadLine();
                    inputFileLines.Add(curLine);
                }
            }

            return inputFileLines;
        }
    }
}
