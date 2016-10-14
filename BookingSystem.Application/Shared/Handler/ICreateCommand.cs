using Abp.Domain.Entities;

namespace BookingSystem.Shared.Handler
{
    public interface ICreateCommand<out T> where T: Entity
    {
    }
}