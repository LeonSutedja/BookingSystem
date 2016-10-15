using System.ComponentModel.DataAnnotations;
using Abp.Domain.Repositories;
using BookingSystem.Shared.Handler;
using BookingSystem.Shared.Handler.Validation;

namespace BookingSystem.Rooms.Command
{
    public class DeleteRoomCommand : IDeleteCommand<Room>
    {
        [Required]
        public int Id { get; set; }
    }

    public class CannotDeleteRoomCalledJohn : IBusinessRule<DeleteRoomCommand, Room>
    {
        private readonly IRepository<Room> _roomRepository;

        public CannotDeleteRoomCalledJohn(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public ValidationCommandResult IsValid(DeleteRoomCommand command)
        {
            var entity = _roomRepository.FirstOrDefault(command.Id);
            if (entity.Name == "John") return ValidationCommandResult.NotValid("Room Name is John");
            return ValidationCommandResult.Valid();
        }
    }
}
