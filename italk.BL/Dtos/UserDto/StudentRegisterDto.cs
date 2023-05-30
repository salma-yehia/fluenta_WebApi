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
    public string Password { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Level { get; set; } = string.Empty;
    public enum GenderType
    {
        Empty,
        Male,
        Female
    }
    public GenderType Gender { get; set; } = GenderType.Empty;
}
