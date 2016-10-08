namespace BookingSystem
{
    using System;
    using Abp.Domain.Entities;

    public class Customer : Entity<int>
    {
        public static Customer Create(string firstName, string lastName, DateTime dob)
        {
            return new Customer(firstName, lastName, dob);
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        // EF purpose only
        protected Customer() { }

        private Customer(string firstName, string lastName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
        }

        public void ChangeName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void ChangeDateOfBirth(DateTime newDob)
        {
            DateOfBirth = newDob;
        }
    }
}
