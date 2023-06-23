using italk.DAL.Data.Models;
using italk.DAL;
using static italk.DAL.CrsEnums;

namespace italk.BL;
public class CourseReadDto
{
    public int Id { get; set; }
    public string Picture { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public int PLacesLeft { get; set; }
    public DateTime Appointment { get; set; }
    public Category CrsCategory { get; set; }
    public Level CrsLevel { get; set; }
    public int InstructorId { get; set; }
    public int LanguageId { get; set; }
    

}
