using italk.BL.Dtos.ReservationDto;
using italk.BL.Managers.ReservationManager;
using Microsoft.AspNetCore.Mvc;

namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;

        public StudentController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        [HttpGet("GetReservationForStudent/{id}")]
        public ActionResult<List<ReservationDto>> GetReservationForStudent(int id)
        {
            return _reservationManager.GetReservationsForStudent(id);
        }
    }
}
