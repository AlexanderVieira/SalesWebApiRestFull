using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Seller()
        {

        }

        public Seller(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
