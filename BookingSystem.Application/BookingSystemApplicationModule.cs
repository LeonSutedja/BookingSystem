using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using BookingSystem.Shared.CreateHandler;

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

            IocManager.IocContainer.Register(
                Classes.FromThisAssembly()
                .BasedOn(typeof(ICreateHandler<>))
                .WithService.AllInterfaces()
                .LifestyleTransient()
                .AllowMultipleMatches());

            IocManager.IocContainer.Register(Component.For(typeof(ICreateHandlerFactory))
                .ImplementedBy(typeof(CreateHandlerFactory))
                .LifestyleTransient());
        }
    }
}
