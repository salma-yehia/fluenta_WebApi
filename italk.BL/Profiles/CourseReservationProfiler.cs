using AutoMapper;
using italk.DAL;

namespace italk.BL;

public class CourseReservationProfiler: Profile
{
    public CourseReservationProfiler()
    {
        CreateMap<CourseReservation, AddCourseReservationDto>();
        CreateMap<AddCourseReservationDto,CourseReservation>();
    }
    
}
