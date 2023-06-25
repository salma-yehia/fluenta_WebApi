using italk.DAL.Data.Models;
using italk.DAL;
using italk.BL.Dtos.UserDto;

namespace italk.BL;

public class CourseReservationDto
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime Appointment { get; set; }
    public StudentDto Student { get; set; } = null!;
    public CourseReadDto Course { get; set; } = null!;
}
