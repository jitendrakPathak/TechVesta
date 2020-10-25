using System;
using System.ComponentModel.DataAnnotations;

namespace TechVesta.Web.DTO
{
    public class CheckoutDTO
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
    }
}
