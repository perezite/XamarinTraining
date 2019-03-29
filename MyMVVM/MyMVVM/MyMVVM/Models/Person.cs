using System;
using System.Collections.Generic;
using System.Text;

namespace MyMVVM.Models
{
    public class Person
    {
        public string FullName => $"{FirstName} {LastName}";

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
