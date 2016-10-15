using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using BookingSystem.Shared.Handler.Create;
using BookingSystem.Shared.Handler.Delete;
using BookingSystem.Shared.Handler.Validation;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

namespace BookingSystem
{
    [DependsOn(typeof(BookingSystemCoreModule), typeof(AbpAutoMapperModule))]
    public class BookingSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Kernel.Resolver
                .AddSubResolver(new CollectionResolver(IocManager.IocContainer.Kernel));

            IocManager.IocContainer.Register(
                Classes.FromThisAssembly()
                .BasedOn(typeof(IBusinessRule<,>))
                .WithService.AllInterfaces()
                .LifestyleTransient()
                .AllowMultipleMatches());

            IocManager.IocContainer.Register(
                Component.For(typeof(IDeleteHandler<,>))
                .ImplementedBy(typeof(GenericDeleteHandler<,>))
                .LifestyleTransient());

            IocManager.IocContainer.Register(Component.For(typeof(IDeleteHandlerFactory))
                .ImplementedBy(typeof(DeleteHandlerFactory))
                .LifestyleTransient());

            IocManager.IocContainer.Register(
                Component.For(typeof(ICreateHandler<,>))
                .ImplementedBy(typeof(GenericCreateHandler<,>))
                .LifestyleTransient());

            IocManager.IocContainer.Register(Component.For(typeof(ICreateHandlerFactory))
                .ImplementedBy(typeof(CreateHandlerFactory))
                .LifestyleTransient());

            IocManager.IocContainer.Register(
                Classes.FromThisAssembly()
                .BasedOn(typeof(ICreateCommandMapper<,>))
                .WithService.AllInterfaces()
                .LifestyleTransient()
                .AllowMultipleMatches());

            IocManager.IocContainer.Register(Component.For(typeof(ICreateCommandMapperFactory))
                .ImplementedBy(typeof(CreateCommandMapperFactory))
                .LifestyleTransient());
        }
    }
}
