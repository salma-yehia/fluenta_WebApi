using AutoMapper;
using italk.BL.Dots;
using italk.BL.Dtos.ReservationDto;
using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<AddReservationDto, Reservation>();
        }
    }
}
