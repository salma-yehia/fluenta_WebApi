using italk.DAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using italk.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace italk.DAL.Repos.Instructors
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly Context _context;

        public InstructorRepo(Context context)
        {
            _context = context;
        }
        public IQueryable<Instructor> GetInstructorsByLanguage(int id)
        {
            return _context.Instructors.Where(l => l.LanguageId == id);
        }

    }
}
