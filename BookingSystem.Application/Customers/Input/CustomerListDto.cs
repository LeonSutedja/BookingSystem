namespace BookingSystem.Customers.Input
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Customer))]
    public class CustomerListDto : EntityDto<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }   
}
