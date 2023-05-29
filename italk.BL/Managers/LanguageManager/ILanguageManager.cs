using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;

namespace italk.BL.Managers.LanguageManager
{
    public interface ILanguageManager
    {
        List<InstructorDto> GetInstructorOfLanguage(int languadeId);
    }
}