using AutoMapper;
using italk.BL.Dtos.CourseReservationDto;
using italk.BL.Dtos.UserDto;
using italk.DAL;
using italk.DAL.Data.Models;

namespace italk.BL;

public class CourseReservationProfiler: Profile
{
    public CourseReservationProfiler()
    {
        CreateMap<CourseReservation, AddCourseReservationDto>();
        CreateMap<AddCourseReservationDto, CourseReservation>();
        CreateMap<Student, StudentDto>();
        CreateMap<Course, CourseReadDto>();
        CreateMap<CourseReservation, CourseReservationDto>();


    }

}
