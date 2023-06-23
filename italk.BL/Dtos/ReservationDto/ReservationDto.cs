using italk.BL.Dtos.UserDto;

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
