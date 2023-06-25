using italk.DAL.Data.Models;
using static italk.DAL.CrsEnums;

namespace italk.DAL;
public class Course
{
    public int Id { get; set; }
    public string Picture { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public int NumOfPlaces { get; set; }
    public int PLacesLeft { get; set; }
    public DateTime Appointment { get; set; }
    public Category CrsCategory { get; set; }
    public Level CrsLevel { get; set; }
    public int InstructorId { get; set; }
    public int LanguageId { get; set; }
    public Language Language { get; set; } = null!;
    public Instructor Instructor { get; set; } = null!;
    public ICollection<CourseReservation> CrsReservations { get; set; }=new List<CourseReservation>();


}
