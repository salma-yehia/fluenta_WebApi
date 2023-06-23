using italk.DAL.Data.Models;

namespace italk.DAL.Repos.Question
{
    public interface IQuestionsRepo
    {
        IEnumerable<Questions> GetAllQuestions();
    }
}