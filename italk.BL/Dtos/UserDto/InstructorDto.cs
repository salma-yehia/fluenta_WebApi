using italk.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Dtos.UserDto
{
    public class InstructorDto
    {
        public string UserName { get; set; } = string.Empty;
        public int LanguageId { get; set; }
        public string Imgname { get; set; } = string.Empty;
        public enum GenderType
        {
            Empty,
            Male,
            Female
        }
        public GenderType Gender { get; set; } = GenderType.Empty;
    }
}
