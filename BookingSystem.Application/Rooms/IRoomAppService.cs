namespace BookingSystem.Rooms
{
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using BookingSystem.Shared;
    using Input;
    using System.Threading.Tasks;

    public interface IRoomAppService : IApplicationService
    {
        HandlerResponse CreateRoom(CreateRoomInput input);

        HandlerResponse DeleteRoom(DeleteRoomInput input);

        Task<ListResultDto<RoomListDto>> GetRooms();
    }
}
