using italk.BL.Dtos.QuestionsDto;
using italk.BL.Managers.QuestionsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsManager _questionsManager;

        public QuestionsController(IQuestionsManager questionsManager)
        {
            _questionsManager = questionsManager;
        }
        [HttpGet ("GetAllQuestions")]
        public ActionResult<List<QuestionsDto>> GetAllQuestions()
        {
            var questionsDto = _questionsManager.GetAllQuestions();

            if (questionsDto == null)
            {
                return NotFound(); 
            }

            return Ok(questionsDto);
        }
    }
}
