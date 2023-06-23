using italk.BL.Dtos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Dtos.QuestionsDto
{
    public class QuestionsDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public ICollection<OptionsDto> Options { get; set; } = new List<OptionsDto>();
    }
}
