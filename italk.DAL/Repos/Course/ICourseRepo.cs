using italk.DAL.Data.Models;
using static italk.DAL.CrsEnums;

namespace italk.DAL;

public interface ICourseRepo
{
    IQueryable<Course> GetCourseByLanguage(int id);
    IQueryable<Course> GetCourseByLevel(Level level);
    IQueryable<Course> GetCourseByCategory(Category category);
    void AddCourse(Course course);
}
