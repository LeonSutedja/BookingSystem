namespace BookingSystem.Rooms
{
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Repositories;
    using Abp.AutoMapper;
    using BookingSystem.Shared;
    using BookingSystem.Rooms.Input;
    using BookingSystem.Shared.CreateHandler;
    using System.Collections.Generic;
    using System;

    public class RoomAppService : BookingSystemAppServiceBase, IRoomAppService
    {
        private ICreateHandlerFactory _createHandlerFactory;
        private IRepository<Room, int> _roomRepository;

        public RoomAppService(ICreateHandlerFactory createHandlerFactory, IRepository<Room, int> roomRepository)
        {
            _createHandlerFactory = createHandlerFactory;
            _roomRepository = roomRepository;
        }

        public HandlerResponse CreateRoom(CreateRoomInput input)
        {
            var handler = _createHandlerFactory.CreateHandler<CreateRoomInput>();
            var result = handler.Create(input);
            return result;
        }

        public HandlerResponse DeleteRoom(DeleteRoomInput input)
        {
            var handler = _createHandlerFactory.CreateHandler<DeleteRoomInput>();
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
