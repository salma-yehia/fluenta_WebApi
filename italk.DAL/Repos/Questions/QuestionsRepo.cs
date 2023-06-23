using italk.DAL.Data.Context;
using italk.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Repos.Question
{
    public class QuestionsRepo : IQuestionsRepo
    {
        private readonly Context _context;

        public QuestionsRepo(Context context)
        {
            _context = context;
        }
        public IEnumerable<Questions> GetAllQuestions()
        {
            return _context.Set<Questions>().Include(o => o.Options).ToList();
        }
    }
}
