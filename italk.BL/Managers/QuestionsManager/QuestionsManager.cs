using AutoMapper;
using italk.BL.Dtos.QuestionsDto;
using italk.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.BL.Managers.QuestionsManager
{
    public class QuestionsManager : IQuestionsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<QuestionsDto> GetAllQuestions()
        {
            var questions = _unitOfWork.QuestionsRepo.GetAllQuestions();

            var questionsDto = _mapper.Map<IEnumerable<QuestionsDto>>(questions);

            return questionsDto;
        }
    }
}
