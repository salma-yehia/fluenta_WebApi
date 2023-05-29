using AutoMapper;
using italk.BL.Dots;
using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Profiles
{
    public class InstructorProfile:Profile
    {
        public InstructorProfile() {
            CreateMap<InstructorRegisterDto, Instructor>();
        }
    }
}
