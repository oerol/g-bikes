using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public uint PostalCode { get; set; }
    }
}
