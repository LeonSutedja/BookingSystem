namespace BookingSystem.Rooms
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Command;
    using Shared;

    public interface IRoomAppService : IApplicationService
    {
        HandlerResponse CreateRoom(RoomCreateCommand createCommand);

        HandlerResponse DeleteRoom(DeleteRoomCommand input);

        Task<ListResultDto<RoomListDto>> GetRooms();
    }
}
