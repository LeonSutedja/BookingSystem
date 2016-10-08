using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using BookingSystem.EntityFramework;

namespace BookingSystem.Migrator
{
    [DependsOn(typeof(BookingSystemDataModule))]
    public class BookingSystemMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<BookingSystemDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}