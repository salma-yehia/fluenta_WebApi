using italk.DAL.Data.Models;

namespace italk.DAL.Repos.Reservations
{
    public interface IReservationRepo
    {
        bool CheckAppointment(DateTime Appointment, int id);
        IQueryable<Reservation> GetReservationsForInstructor(int id);
        IQueryable<Reservation> GetReservationsForStudent(int id);
        void Add(Reservation reservation);
    }
}