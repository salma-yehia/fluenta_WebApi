using AutoMapper;
using italk.BL.Dots;
using italk.BL.Dtos.Options;
using italk.BL.Dtos.QuestionsDto;
using italk.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Profiles
{
    public class QuestionsProfile:Profile
    {
        public QuestionsProfile()
        {
            CreateMap<Questions, QuestionsDto>();
            CreateMap<Options, OptionsDto>();
        }
    }
}
