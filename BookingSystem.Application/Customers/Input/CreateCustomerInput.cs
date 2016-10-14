namespace BookingSystem.Customers.Input
{
    using System;
    using Shared.Handler;

    public class CreateCustomerInput : ICreateCommand<Customer>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }

    public class CreateCustomerCommandMapper : ICreateCommandMapper<CreateCustomerInput, Customer>
    {
        public Customer Create(CreateCustomerInput command)
        {
            var newCustomer = Customer.Create(
                command.FirstName, 
                command.LastName, 
                command.DateOfBirth.Value);
            return newCustomer;
        }
    }
}
