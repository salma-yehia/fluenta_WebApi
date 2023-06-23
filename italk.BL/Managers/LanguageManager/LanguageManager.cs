using AutoMapper;
using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;
using italk.DAL.UnitOfWork;


namespace italk.BL.Managers.LanguageManager
{
    public class LanguageManager : ILanguageManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LanguageManager(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<InstructorDto> GetInstructorOfLanguage(int languadeId)
        {
            IQueryable<Instructor> instructors = _unitOfWork.InstructorRepo.GetInstructorsByLanguage(languadeId);
            return _mapper.Map<List<InstructorDto>>(instructors);
        }
    }
}
