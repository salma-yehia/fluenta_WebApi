using italk.BL.Dtos.ReservationDto;
using italk.BL.Managers.ReservationManager;
using Microsoft.AspNetCore.Mvc;

namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;

        public ReservationController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }
        [HttpPost("AddReservation")]
        public int AddReservation(AddReservationDto addReservationDto)
        {
            return _reservationManager.Add(addReservationDto);
        }

        [HttpPost("CheckAppointment")]
        public bool CheckAppointment(AddReservationDto addReservationDto)
        {
            return _reservationManager.CheckAppointment(addReservationDto);

        }
    }
}
