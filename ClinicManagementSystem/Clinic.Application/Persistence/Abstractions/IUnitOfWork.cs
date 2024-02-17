namespace ClinicManagement.Application.Persistence.Abstractions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
