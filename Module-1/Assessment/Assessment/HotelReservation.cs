using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment
{
    public class HotelReservation
    {
        public string Name { get; set; }
        public int NumberOfNights { get; set; }
        public decimal EstimatedTotal { set; get; }


        public HotelReservation(string name, int numberOfNights)
        {
            Name = name;
            NumberOfNights = numberOfNights;
            EstimatedTotal = numberOfNights * 59.99M;
        }
        public decimal AddFees(bool usedMinibar, bool requiresCleaning)
        {
            
            if (usedMinibar == true)
            {
                EstimatedTotal = Decimal.Add(EstimatedTotal, 12.99M);
            }
            if (requiresCleaning == true)
            {
                EstimatedTotal = Decimal.Add(EstimatedTotal, 34.99M);
            }
            if (requiresCleaning == true && usedMinibar == true)
            {
                EstimatedTotal = Decimal.Add(EstimatedTotal, 12.99M);
            }
            return EstimatedTotal;
        }

        public override string ToString()
        {
            return "RESERVATION - " + this.Name + " - " + this.EstimatedTotal;
        }
    }
}
