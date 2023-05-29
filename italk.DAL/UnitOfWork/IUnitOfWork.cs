using italk.DAL.Repos.Instructors;
using italk.DAL.Repos.Languages;
using italk.DAL.Repos.Reservations;

namespace italk.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ILanguageRepo LanguageRepo { get; }
        IReservationRepo ReservationRepo { get; }
        IInstructorRepo InstructorRepo { get; }
        int SaveChanges();

    }
}