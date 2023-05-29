using italk.DAL.Data.Models;

namespace italk.DAL.Repos.Instructors
{
    public interface IInstructorRepo
    {
        IQueryable<Instructor> GetInstructorsByLanguage(int id);
    }
}