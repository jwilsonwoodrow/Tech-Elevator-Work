using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Models
{
    public class Car
    {
        public int Year;
        public string Make;
        public bool IsClassicCar;
        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.Year;
            }
        }
        public Car(int year, string make, bool isClassicCar)
        {
            this.Year = year;
            this.Make = make;
            this.IsClassicCar = isClassicCar;
        }
        public bool needsECheck(int yearToCheck)
        {
            if (this.Age < 4 || this.Age > 25 || this.IsClassicCar) {
                return false;
            }
            if (yearToCheck%2==0 && this.Year%2==0)
            {
                return true;
            } else if (yearToCheck%2==1 && this.Year%2==1) {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"CAR - {this.Year} - {this.Make}";
        }
    }
}
