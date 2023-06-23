using italk.BL.Dtos.UserDto;
namespace italk.BL.Managers.LanguageManager
{
    public interface ILanguageManager
    {
        List<InstructorDto> GetInstructorOfLanguage(int languadeId);
    }
}