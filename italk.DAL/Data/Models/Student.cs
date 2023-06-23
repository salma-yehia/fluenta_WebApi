using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Data.Models
{
    public class Student:BaseModel
    {
        public int Age { get; set; }
        public string Level { get; set; } = string.Empty;
        public ICollection<Reservation> Resrvations { get; set; } = new List<Reservation>();
        public ICollection<CourseReservation> CrsReservations { get; set; } = new List<CourseReservation>();

    }
}
