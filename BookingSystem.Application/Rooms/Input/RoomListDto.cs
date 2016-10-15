namespace BookingSystem.Rooms.Command
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Room))]
    public class RoomListDto : EntityDto<int>
    {
        public string Name { get; set; }

        public int NumberOfPeople { get; set; }
    }   
}
