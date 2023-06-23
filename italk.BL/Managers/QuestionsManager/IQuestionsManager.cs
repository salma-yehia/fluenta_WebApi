using italk.BL.Dtos.QuestionsDto;

namespace italk.BL.Managers.QuestionsManager
{
    public interface IQuestionsManager
    {
        IEnumerable<QuestionsDto> GetAllQuestions();
    }
}