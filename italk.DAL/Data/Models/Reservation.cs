using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Data.Models
{
    public class Reservation
    {
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public DateTime Appointment { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public Student Student { get; set; } = null!;

    }
}
