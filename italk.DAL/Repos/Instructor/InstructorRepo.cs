using italk.DAL.Data.Context;
using italk.DAL.Data.Models;


namespace italk.DAL.Repos.Instructors
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly Context _context;

        public InstructorRepo(Context context)
        {
            _context = context;
        }
        public IQueryable<Instructor> GetInstructorsByLanguage(int id)
        {
            return _context.Instructors.Where(l => l.LanguageId == id);
        }

    }
}
