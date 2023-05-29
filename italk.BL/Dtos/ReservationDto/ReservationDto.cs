using italk.BL.Dots;
using italk.BL.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Dtos.ReservationDto
{
    public class ReservationDto
    {
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public DateTime Appointment { get; set; }
        public StudentDto Student { get; set; } = null!;
        public InstructorDto Instructor { get; set; } = null!;

    }
}
