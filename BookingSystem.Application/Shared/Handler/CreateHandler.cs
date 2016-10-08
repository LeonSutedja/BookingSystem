using Abp.Dependency;

namespace BookingSystem.Shared.CreateHandler
{
    public interface ICreateHandler<T>
    {
        HandlerResponse Create(T input);
    }

    public interface ICreateHandlerFactory
    {
        ICreateHandler<T> CreateHandler<T>();
    }

    public class CreateHandlerFactory : ICreateHandlerFactory
    {
        private readonly IIocResolver _iocResolver;

        public CreateHandlerFactory(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        public ICreateHandler<T> CreateHandler<T>()
            => (ICreateHandler<T>)_iocResolver.Resolve(typeof(ICreateHandler<>).MakeGenericType(typeof(T)));
    }
}
