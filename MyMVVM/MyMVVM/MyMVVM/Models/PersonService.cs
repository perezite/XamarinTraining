using System;
using System.Collections.Generic;
using System.Text;

namespace MyMVVM.Models
{
    public class PersonService
    {
        public List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person { FirstName = "Hans", LastName = "Mustermann" },
                new Person { FirstName = "Donald", LastName = "Trump" }
            };
        }
    }
}
