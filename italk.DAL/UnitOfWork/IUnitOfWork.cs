using italk.DAL.Repos.Question;
using italk.DAL.Repos.Instructors;
using italk.DAL.Repos.Languages;
using italk.DAL.Repos.Reservations;

namespace italk.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ILanguageRepo LanguageRepo { get; }
        IReservationRepo ReservationRepo { get; }
        ICourseReservationRepo CourseReservationRepo { get; }
        IInstructorRepo InstructorRepo { get; }
        IQuestionsRepo QuestionsRepo { get; }

        ICourseRepo CourseRepo { get; }
        int SaveChanges();

    }
}