namespace BookingSystem.Customers
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Input;
    using Shared;

    public interface ICustomerAppService : IApplicationService
    {
        HandlerResponse CreateCustomer(CustomerInput input);

        HandlerResponse DeleteCustomer(DeleteCustomerInput input);

        Task<ListResultDto<CustomerListDto>> GetCustomers();
    }
}
