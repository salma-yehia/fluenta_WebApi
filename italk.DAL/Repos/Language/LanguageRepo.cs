using italk.DAL.Data.Context;
using italk.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Repos.Languages
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly Context _context;

        public LanguageRepo(Context context)
        {
            _context = context;
        }

        public Language.LangName GetLanguageName(int id)
        {
            var language = _context.Set<Language>().FirstOrDefault(n => n.Id == id);
            if (language != null)
            {
                return language.LanguageName;
            }
            return Language.LangName.Empty;
        }
    }
}
