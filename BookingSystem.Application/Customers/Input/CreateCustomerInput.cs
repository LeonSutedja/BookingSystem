using System;
using System.ComponentModel.DataAnnotations;
using BookingSystem.Shared.Handler;
using BookingSystem.Shared.Handler.Create;

namespace BookingSystem.Customers.Input
{
    public class CustomerInput : ICreateCommand<Customer>
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }
    }

    public class CreateCustomerCommandMapper : ICreateCommandMapper<CustomerInput, Customer>
    {
        public Customer Create(CustomerInput command)
        {
            var newCustomer = Customer.Create(
                command.FirstName, 
                command.LastName, 
                command.DateOfBirth.Value);
            return newCustomer;
        }
    }
}
