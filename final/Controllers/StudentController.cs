using italk.BL.Dots;
using italk.BL.Dtos.ReservationDto;
using italk.BL.Managers.AccManager;
using italk.BL.Managers.ReservationManager;
using Microsoft.AspNetCore.Mvc;

namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;
        private readonly IAccManager _accManager;

        public StudentController(IReservationManager reservationManager , IAccManager accManager)
        {
            _reservationManager = reservationManager;
            _accManager = accManager;
        }

        [HttpGet("GetReservationForStudent/{id}")]
        public ActionResult<List<ReservationDto>> GetReservationForStudent(int id)
        {
            return _reservationManager.GetReservationsForStudent(id);
        }
        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<StudentRegisterDto>> GetStudentById(int id)
        {
            var student = await _accManager.GetStudentById(id);
            return student;
        }
    }
}
