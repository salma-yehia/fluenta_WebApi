using AutoMapper;
using italk.BL.Dots;
using italk.DAL.Data.Models;
namespace italk.BL.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentRegisterDto, Student>();
            CreateMap<Student, StudentRegisterDto>();

        }
    }
}
