using italk.DAL.Data.Context;
using static italk.DAL.CrsEnums;

namespace italk.DAL;

public class CourseRepo : ICourseRepo
{
    private readonly Context _context;

    public CourseRepo(Context context)
    {
        _context = context;
    }
    public IQueryable<Course> GetCourseByCategory(Category category)
    {
        return _context.Courses.Where(l => l.CrsCategory == category);
    }

    public IQueryable<Course> GetCourseByLanguage(int id)
    {
        return _context.Courses.Where(l => l.LanguageId == id);
    }

    public IQueryable<Course> GetCourseByLevel(Level level)
    {
        return _context.Courses.Where(l => l.CrsLevel == level);  
    }

    public void AddCourse(Course course)
    {
        course.Id = _context.Courses.Count() + 1;
        _context.Courses.Add(course);
    }

}
