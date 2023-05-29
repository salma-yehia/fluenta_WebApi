using italk.DAL.Data.Models;

namespace italk.DAL.Repos.Languages
{
    public interface ILanguageRepo
    {
        Language.LangName GetLanguageName(int id);
    }
}