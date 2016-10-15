using Abp.Domain.Entities;

namespace BookingSystem.Shared.Handler
{
    public interface ICommand<out T> where T : Entity
    {        
    }

    public interface ICreateCommand<out T> : ICommand<T> where T: Entity
    {
    }

    public interface IUpdateCommand<out T> : ICommand<T> where T : Entity
    {
        int Id { get; }
    }

    public interface IDeleteCommand<out T> : ICommand<T> where T : Entity
    {
        int Id { get; }
    }
}