namespace BookingSystem.Rooms.Input
{
    using Shared;
    using Shared.CreateHandler;
    using Abp.Domain.Repositories;

    public class CreateRoomInput
    {
        public string Name { get; set; }
    }

    public class CreateRoomInputHandler : ICreateHandler<CreateRoomInput>
    {
        private IRepository<Room, int> _roomRepository;

        public CreateRoomInputHandler(IRepository<Room, int> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public HandlerResponse Create(CreateRoomInput input)
        {
            if (string.IsNullOrEmpty(input.Name)) return HandlerResponse.Failed("Name must not be empty");
            var newRoom = Room.Create(input.Name);
            var newId = _roomRepository.InsertAndGetId(newRoom);
            
            return HandlerResponse.Success("Room Created!", newId);
        }        
    }
}
