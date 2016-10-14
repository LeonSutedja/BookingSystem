namespace BookingSystem.Rooms
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Input;
    using Shared;

    public interface IRoomAppService : IApplicationService
    {
        HandlerResponse CreateRoom(CreateRoomInput input);

        HandlerResponse DeleteRoom(DeleteRoomInput input);

        Task<ListResultDto<RoomListDto>> GetRooms();
    }
}
