namespace BookingSystem.Rooms.Input
{
    using Shared;
    using Abp.Domain.Repositories;

    public class DeleteRoomInput
    {
        public int Id { get; set; }
    }

    //public class DeleteRoomInputHandler : ICreateHandler<DeleteRoomInput>
    //{
    //    private IRepository<Room, int> _roomRepository;

    //    public DeleteRoomInputHandler(IRepository<Room, int> roomRepository)
    //    {
    //        _roomRepository = roomRepository;
    //    }

    //    public HandlerResponse Create(DeleteRoomInput input)
    //    {
    //        var isRoomExists = _roomRepository.FirstOrDefault(input.Id) != null;
    //        if (!isRoomExists) return HandlerResponse.Failed("Room cannot be found");
    //        _roomRepository.Delete(input.Id);
            
    //        return HandlerResponse.Success("Room Deleted!", input.Id);
    //    }        
    //}
}
