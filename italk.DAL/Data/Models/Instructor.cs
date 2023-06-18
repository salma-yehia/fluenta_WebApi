using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Data.Models
{
    public class Instructor:BaseModel
    {
        public int LanguageId { get; set; } 
        public int Degree { get; set; }
        public DateTime Appointment { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Descroption { get; set; } = string.Empty;
        public string ImgName { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string TeachingCertificate { get; set; } = string.Empty;
        public string ExtraCourses { get; set; } = string.Empty;
        public ICollection<Reservation> Resrvations { get; set; } = new List<Reservation>();
        public Language Language { get; set; } = null!;
    }
}
