using italk.BL.Dots;
using italk.BL.Dtos.ReservationDto;
using italk.BL.Dtos.UserDto;
using italk.BL.Managers.AccManager;
using italk.BL.Managers.LanguageManager;
using italk.BL.Managers.ReservationManager;
using italk.DAL.Data.Models;
using italk.DAL.Repos.Instructors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly ILanguageManager _languageManager;
        private readonly IReservationManager _reservationManager;
        private readonly IAccManager _accManager;

        public InstructorController(ILanguageManager languageManager , IReservationManager reservationManager , IAccManager accManager)
        {
            _languageManager = languageManager;
            _reservationManager = reservationManager;
            _accManager = accManager;
        }
        [HttpGet("GetInstructorsForLanguage/{languageId}")]
        public ActionResult<List<InstructorDto>> GetInstructorsForLanguage(int languageId)
        {
           return _languageManager.GetInstructorOfLanguage(languageId);
        }
        [HttpGet("GetReservationForInstructor/{id}")]
        public ActionResult<List<ReservationDto>> GetReservationForInstructor(int id)
        {
           return _reservationManager.GetReservationsForInstructor(id);
        }
        [HttpGet("GetInstructorById/{id}")]
        //[Authorize(Policy = "instructor")]

        public async Task<ActionResult<InstructorRegisterDto>> GetInstructorById(int id)
        {
            var instructor=await _accManager.GetInstructorById(id);
            return instructor;
        }
    }
}
