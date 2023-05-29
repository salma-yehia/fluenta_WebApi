using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Dtos.ReservationDto
{
    public class AddReservationDto
    {
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public DateTime Appointment { get; set; }
    }
}
