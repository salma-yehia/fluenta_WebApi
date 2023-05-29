using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Dots;

public class InstructorRegisterDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int Degree { get; set; }
    public DateTime Appointment { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string Descroption { get; set; } = string.Empty;
    public string Imgname { get; set; } = string.Empty;
    public string Experience { get; set; } = string.Empty;
    public string TeachingCertificate { get; set; } = string.Empty;
    public string ExtraCourses { get; set; } = string.Empty;
    public enum GanderType
    {
        Empty,
        Male,
        Female
    }
    public GanderType Gander { get; set; } = GanderType.Empty;
    public int LanguageId { get; set; }
}
