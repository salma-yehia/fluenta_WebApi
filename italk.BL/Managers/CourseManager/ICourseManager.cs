namespace italk.BL;
public interface ICourseManager
{
    List<CourseReadDto> GetCourseByLanguage(int id);
    List<CourseReadDto> GetCourseByLevel(string  level);
    List<CourseReadDto> GetCourseByCategory(string category);
    void AddCourse(CourseAddDto courseAddDto);   
}
