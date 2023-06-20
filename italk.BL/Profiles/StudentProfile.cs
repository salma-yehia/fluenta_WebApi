using AutoMapper;
using italk.BL.Dots;
using italk.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
