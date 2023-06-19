using italk.BL.Dtos.ReservationDto;
using italk.DAL.Data.Models;

namespace italk.BL.Managers.ReservationManager
{
    public interface IReservationManager
    {
        bool CheckAppointment(AddReservationDto addreservationDto);
        List<ReservationDto> GetReservationsForInstructor(int id);
        List<ReservationDto> GetReservationsForStudent(int id);
        int Add(AddReservationDto addReservationDto);

    }
}