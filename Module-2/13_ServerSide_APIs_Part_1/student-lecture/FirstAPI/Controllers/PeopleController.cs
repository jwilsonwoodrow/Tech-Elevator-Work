using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Controllers
{
    [Route("people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        //pretend there is a dao
        private static List<Person> people = new List<Person>()
            {
                new Person(1, "Mike", 71),
                new Person(2, "Kareem", 86),
                new Person(3, "JD", 72),
                new Person(4, "Janitor", 77)
            };

        [HttpGet] //call this method if a GET is recieved 
        public List<Person> AnyName()
        {
            return people;
        }

        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            Person person = people.Find( p => p.ID == id); //using linq, replaces foreach loop
            return person;
        }

    }
}
