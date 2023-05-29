using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Data.Models
{
    public class BaseModel:IdentityUser<int>
    {
        public enum GenderType
        {
            Empty,
            Male,
            Female
        }
        public GenderType Gender { get; set; } = GenderType.Empty;
    }
}
