using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Dtos.UserDto
{
    public class StudentDto
    {
        public string UserName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Level { get; set; } = string.Empty;
        public enum GenderType
        {
            Empty,
            Male,
            Female
        }
        public GenderType Gender { get; set; } = GenderType.Empty;
    }
}

