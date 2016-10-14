namespace BookingSystem.Shared.Handler
{
    using Abp.Domain.Entities;
    using Abp.Dependency;

    public interface ICreateHandler<in TCommand, TEntity>
        where TEntity : Entity
        where TCommand : ICreateCommand<TEntity>
    {
        HandlerResponse Create(TCommand input);
    }

    public interface ICreateHandlerFactory
    {
        ICreateHandler<TCommand, TEntity> CreateHandler<TCommand, TEntity>() 
            where TEntity : Entity
            where TCommand : ICreateCommand<TEntity>;
    }

    public class CreateHandlerFactory : ICreateHandlerFactory
    {
        private readonly IIocResolver _iocResolver;

        public CreateHandlerFactory(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        public ICreateHandler<TCommand, TEntity> CreateHandler<TCommand, TEntity>()
            where TEntity : Entity
            where TCommand : ICreateCommand<TEntity>
            => _iocResolver.Resolve<ICreateHandler<TCommand, TEntity>>();
    }
}
