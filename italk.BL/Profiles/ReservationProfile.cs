using AutoMapper;
using italk.BL.Dtos.ReservationDto;
using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;


namespace italk.BL.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<AddCourseReservationDto, Reservation>();
        }
    }
}
