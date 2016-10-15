using BookingSystem.Shared.Handler.Create;
using BookingSystem.Shared.Handler.Delete;

namespace BookingSystem.Rooms
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Repositories;
    using Abp.AutoMapper;
    using Shared;
    using Command;
    
    public class RoomAppService : BookingSystemAppServiceBase, IRoomAppService
    {
        private readonly ICreateHandlerFactory _createHandlerFactory;
        private readonly IDeleteHandlerFactory _deleteHandlerFactory;
        private readonly IRepository<Room, int> _roomRepository;

        public RoomAppService(
            ICreateHandlerFactory createHandlerFactory, 
            IDeleteHandlerFactory deleteHandlerFactory, 
            IRepository<Room, int> roomRepository)
        {
            _createHandlerFactory = createHandlerFactory;
            _deleteHandlerFactory = deleteHandlerFactory;
            _roomRepository = roomRepository;
        }

        public HandlerResponse CreateRoom(RoomCreateCommand createCommand)
        {
            var handler = _createHandlerFactory.CreateHandler<RoomCreateCommand, Room>();
            var result = handler.Create(createCommand);
            return result;
        }

        public HandlerResponse DeleteRoom(DeleteRoomCommand input)
        {
            var handler = _deleteHandlerFactory.CreateHandler<DeleteRoomCommand, Room>();
            var result = handler.Create(input);
            return result;
        }

        public async Task<ListResultDto<RoomListDto>> GetRooms()
        {
            var rooms = await _roomRepository.GetAllListAsync();

            var dtoList = rooms.MapTo<List<RoomListDto>>();
            return new ListResultDto<RoomListDto>(dtoList);
        }
    }
}
