using italk.BL.Dtos.ReservationDto;
using italk.BL.Dtos.UserDto;
using italk.BL.Managers.LanguageManager;
using italk.BL.Managers.ReservationManager;
using italk.DAL.Data.Models;
using italk.DAL.Repos.Instructors;
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

        public InstructorController(ILanguageManager languageManager , IReservationManager reservationManager)
        {
            _languageManager = languageManager;
            _reservationManager = reservationManager;
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
    }
}
