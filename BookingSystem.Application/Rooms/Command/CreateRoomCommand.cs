using System.ComponentModel.DataAnnotations;
using System.Linq;
using Abp.Domain.Repositories;
using BookingSystem.Shared.Handler;
using BookingSystem.Shared.Handler.Create;
using BookingSystem.Shared.Handler.Validation;

namespace BookingSystem.Rooms.Command
{
    public class RoomCreateCommand : ICreateCommand<Room>
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }
    }

    public class CreateRoomCommandMapper : ICreateCommandMapper<RoomCreateCommand, Room>
    {
        public Room Create(RoomCreateCommand createCommand)
        {
            var newRoom = Room.Create(createCommand.Name, createCommand.NumberOfPeople);
            return newRoom;
        }
    }

    public class RoomMustHaveMoreThan5NumberOfPeople : IBusinessRule<RoomCreateCommand, Room>
    {
        public ValidationCommandResult IsValid(RoomCreateCommand createCommand)
        {
            if (createCommand.NumberOfPeople < 5) return ValidationCommandResult.NotValid("Room need more than 5 people minimum.");
            return ValidationCommandResult.Valid();
        }
    }

    public class RoomMustHaveMoreThan10NumberOfPeople : IBusinessRule<RoomCreateCommand, Room>
    {
        public ValidationCommandResult IsValid(RoomCreateCommand createCommand)
        {
            if (createCommand.NumberOfPeople < 10) return ValidationCommandResult.NotValid("Room need more than 10 people minimum.");
            return ValidationCommandResult.Valid();
        }
    }

    public class IfFirstCustomerIsCalledJohnCannotCreateRoom 
        : IBusinessRule<RoomCreateCommand, Room>
    {
        private readonly IRepository<Customer> _customerRepository;

        public IfFirstCustomerIsCalledJohnCannotCreateRoom(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ValidationCommandResult IsValid(RoomCreateCommand createCommand)
        {
            var allCustomers = _customerRepository.GetAll().ToList();
            if (allCustomers.Count > 0)
            {
                var firstCustomer = allCustomers.ToList()[0];
                if (firstCustomer.FirstName == "John")
                    return ValidationCommandResult.NotValid("First Customer Is John");
            }
            return ValidationCommandResult.Valid();
        }
    }

}
