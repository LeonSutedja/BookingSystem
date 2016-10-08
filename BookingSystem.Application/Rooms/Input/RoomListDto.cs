namespace BookingSystem.Rooms.Input
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Room))]
    public class RoomListDto : EntityDto<int>
    {
        public string Name { get; set; }
    }   
}
