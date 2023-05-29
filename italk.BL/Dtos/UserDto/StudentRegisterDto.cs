using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Dots;

public class StudentRegisterDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Level { get; set; } = string.Empty;
    public enum GanderType
    {
        Empty,
        Male,
        Female
    }
    public GanderType Gander { get; set; } = GanderType.Empty;
}
