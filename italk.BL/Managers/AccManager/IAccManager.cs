using italk.BL.Dots;
using italk.BL.Dtos.LevelDto;

namespace italk.BL.Managers.AccManager
{
    public interface IAccManager
    {
        Task<RegisterResultDto> InstructorRegister(InstructorRegisterDto instructorRegisterDto);
        Task<TokenDto> Login(LoginDto loginDto);
        Task<RegisterResultDto> StudentRegister(StudentRegisterDto studentRegisterDto);
        Task<StudentRegisterDto> UpdateStudent(int id, StudentRegisterDto studentDto);
        Task<InstructorRegisterDto> UpdateInstructor(int id, InstructorRegisterDto instructorDto);
        Task<StudentRegisterDto> GetStudentById(int id);
        Task<InstructorRegisterDto> GetInstructorById(int id);
        Task<LevelDto> UpdateStudentLevel(int id, LevelDto levelDto);
    }
}