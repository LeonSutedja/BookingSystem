using System.Linq;
using Abp.Application.Editions;
using BookingSystem.Editions;
using BookingSystem.EntityFramework;

namespace BookingSystem.Migrations.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly BookingSystemDbContext _context;

        public DefaultEditionsCreator(BookingSystemDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}