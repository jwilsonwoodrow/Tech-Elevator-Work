using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int HeightInches { get; set; }
        public Person(int id, string name, int heightInches)
        {
            ID = id;
            Name = name;
            HeightInches = heightInches;
        }
    }
}
