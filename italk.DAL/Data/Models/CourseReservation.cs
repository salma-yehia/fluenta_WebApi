using italk.DAL.Data.Models;

namespace italk.DAL;

public class CourseReservation
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime Appointment { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; }=null!;   

}
