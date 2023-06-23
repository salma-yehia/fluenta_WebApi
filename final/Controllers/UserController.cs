using italk.BL.Dots;
using italk.BL.Dtos.LevelDto;
using italk.BL.Managers.AccManager;
using italk.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccManager _accManager;
        public UserController(IAccManager accManager)
        {
            _accManager = accManager;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {

            var result = await _accManager.Login(loginDto);
            if (result.Result != TokenResult.success) { return BadRequest(result); }

            return result;
        }


        [HttpPost("InstructorRegister")]
        public async Task<ActionResult> InstructorRegister(InstructorRegisterDto instructorRegisterDto)
        {
            var result = await _accManager.InstructorRegister(instructorRegisterDto);
            if (!result.IsSuccess) { return BadRequest(result); }

            return NoContent();
        }
        [HttpPost("StudentRegister")]
        public async Task<ActionResult> StudentRegister(StudentRegisterDto studentRegisterDto)
        {
            var result = await _accManager.StudentRegister(studentRegisterDto);
            if (!result.IsSuccess) { return BadRequest(result); }
            return NoContent();

        }
        [HttpPut("UpdateStudent/{id}")]
        //[Authorize(Policy = "student")]
        public async Task<IActionResult> UpdateStudent(int id, StudentRegisterDto studentDto)
        {
            var updatedStudent = await _accManager.UpdateStudent(id, studentDto);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }

        [HttpPut("UpdateInstructor/{id}")]
        //[Authorize(Policy = "instructor")]
        public async Task<IActionResult> UpdateInstructor(int id, InstructorRegisterDto instructorDto)
        {
            var updatedInstructor = await _accManager.UpdateInstructor(id, instructorDto);

            if (updatedInstructor == null)
            {
                return NotFound();
            }

            return Ok(updatedInstructor);
        }

        [HttpPut("UpdateStudentLevel/{id}")]
        //[Authorize(Policy = "instructor")]
        public async Task<IActionResult> UpdateStudentLevel(int id, LevelDto levelDto)
        {
            var updatedStudentLevel = await _accManager.UpdateStudentLevel(id, levelDto);

            if (updatedStudentLevel == null)
            {
                return NotFound();
            }

            return Ok(updatedStudentLevel);
        }
    }
}

