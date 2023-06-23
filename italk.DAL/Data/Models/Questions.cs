using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Data.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Text { get; set;} = string.Empty;
        public ICollection<Options> Options { get; set; } = new List<Options>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
