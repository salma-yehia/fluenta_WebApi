using italk.DAL.Data.Models;

namespace italk.DAL;
public interface ICourseReservationRepo
{
    bool CheckAppointment(DateTime Appointment, int id);
    IQueryable<CourseReservation> GetReservationsForCourse(int id);
    IQueryable<CourseReservation> GetReservationsByStudent(int id);
    void Add(CourseReservation reservation);
}
