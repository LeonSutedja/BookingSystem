namespace BookingSystem.Rooms
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Repositories;
    using Abp.AutoMapper;
    using Shared;
    using Input;
    using Shared.Handler;
    
    public class RoomAppService : BookingSystemAppServiceBase, IRoomAppService
    {
        private readonly ICreateHandlerFactory _createHandlerFactory;
        private readonly IRepository<Room, int> _roomRepository;

        public RoomAppService(
            ICreateHandlerFactory createHandlerFactory, 
            IRepository<Room, int> roomRepository)
        {
            _createHandlerFactory = createHandlerFactory;
            _roomRepository = roomRepository;
        }

        public HandlerResponse CreateRoom(CreateRoomInput input)
        {
            var handler = _createHandlerFactory.CreateHandler<CreateRoomInput, Room>();
            var result = handler.Create(input);
            return result;
        }

        public HandlerResponse DeleteRoom(DeleteRoomInput input)
        {
            //var handler = _createHandlerFactory.CreateHandler<DeleteRoomInput>();
            //var result = handler.Create(input);
            return HandlerResponse.Success("yes", 1);
        }

        public async Task<ListResultDto<RoomListDto>> GetRooms()
        {
            var rooms = await _roomRepository.GetAllListAsync();

            var dtoList = rooms.MapTo<List<RoomListDto>>();
            return new ListResultDto<RoomListDto>(dtoList);
        }
    }
}
