
namespace italk.BL.Dtos.ReservationDto
{
    public class AddReservationDto
    {
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public DateTime Appointment { get; set; }
    }
}
