using AutoMapper;
using italk.DAL;

namespace italk.BL;

public class CourseProfile: Profile
{
    public CourseProfile()
    { 
        CreateMap<Course,CourseReadDto>();
        CreateMap<CourseAddDto,Course>();

    }
}
