using AutoMapper;
using italk.BL.Dots;
using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;
namespace italk.BL.Profiles
{
    public class InstructorProfile:Profile
    {
        public InstructorProfile() {
            CreateMap<InstructorRegisterDto, Instructor>();
            CreateMap<Instructor, InstructorRegisterDto>();
        }
    }
}
