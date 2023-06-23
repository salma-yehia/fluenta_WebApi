namespace italk.BL;

public class AddCourseReservationDto
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime Appointment { get; set; }
}
