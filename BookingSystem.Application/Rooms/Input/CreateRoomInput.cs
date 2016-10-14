using System.ComponentModel.DataAnnotations;
using BookingSystem.Shared.Handler;

namespace BookingSystem.Rooms.Input
{
    public class CreateRoomInput : ICreateCommand<Room>
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }
    }

    public class CreateRoomCommandMapper : ICreateCommandMapper<CreateRoomInput, Room>
    {
        public Room Create(CreateRoomInput command)
        {
            var newRoom = Room.Create(command.Name, command.NumberOfPeople);
            return newRoom;
        }
    }
}
