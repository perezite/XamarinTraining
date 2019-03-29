using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMVVM.Models
{
    public class PersonService
    {
        private List<string> _firstNames = new List<string> { "Anna", "Hans", "Isabella", "Johann", "Linda" };
        private List<string> _lastNames = new List<string> { "Meyer", "Müller", "Durrer", "Herren", "Ziegler" };

        public List<Person> GetPersons()
        {
            var persons = new List<Person>();
            var random = new Random();
            var numPersons = random.Next(5, 10);
            for (var i = 0; i < numPersons; i++)
                persons.Add(GetPerson());

            return persons;
        }

        private Person GetPerson()
        {
            var random = new Random();
            var firstName = _firstNames.OrderBy(x => random.Next(0, _firstNames.Count)).First();
            var lastName = _lastNames.OrderBy(x => random.Next(0, _lastNames.Count)).First();
            return new Person { FirstName = firstName, LastName = lastName };
        }
    }
}
