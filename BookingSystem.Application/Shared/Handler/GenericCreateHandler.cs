namespace BookingSystem.Shared.Handler
{
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;

    public class GenericCreateHandler<TCommand, TEntity> : ICreateHandler<TCommand, TEntity> 
        where TEntity : Entity
        where TCommand : ICreateCommand<TEntity>
    {
        private readonly IRepository<TEntity> _tRepository;
        private readonly ICreateCommandMapperFactory _commandMapperFactory;

        public GenericCreateHandler(
            IRepository<TEntity> tRepository, 
            ICreateCommandMapperFactory commandMapperFactory)
        {
            _tRepository = tRepository;
            _commandMapperFactory = commandMapperFactory;
        }

        public HandlerResponse Create(TCommand input)
        {
            // do validation
            var isValid = true;
            if (!isValid) return HandlerResponse.Failed("Not Valid");

            var mapper = _commandMapperFactory.Create<TCommand, TEntity>();
            var entity = mapper.Create(input);

            var id = _tRepository.InsertAndGetId(entity);
            return HandlerResponse.Success("Created", id);
        }
    }
}