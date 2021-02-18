using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        //list employees on this project
        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException(); //when called, excecute sql query 
        }
    }
}
