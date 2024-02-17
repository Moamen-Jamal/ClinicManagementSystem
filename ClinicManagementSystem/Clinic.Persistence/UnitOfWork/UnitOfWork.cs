using ClinicManagement.Application.Persistence.Abstractions;

namespace ClinicManagement.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesContext _context;
        public UnitOfWork(EntitiesContext context)
        {
            _context = context;
        }

        public void Commit()
        {

            _context.SaveChanges();

        }
    }
}
