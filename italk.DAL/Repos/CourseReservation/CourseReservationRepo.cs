using italk.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace italk.DAL;
public class CourseReservationRepo: ICourseReservationRepo
{
    private readonly Context _context;

    public CourseReservationRepo(Context context)
    {
        _context = context;
    }
    public void Add(CourseReservation reservation)
    {
        _context.Set<CourseReservation>().Add(reservation);
    }
    public IQueryable<CourseReservation> GetReservationsForCourse(int id)
    {
        return _context.Set<CourseReservation>().Include(i => i.Course).Where(r => r.CourseId == id);
    }
    public IQueryable<CourseReservation> GetReservationsByStudent(int id)
    {
        return _context.Set<CourseReservation>().Include(i => i.Student).Where(r => r.StudentId == id);
    }
    public bool CheckAppointment(DateTime Appointment, int id)
    {
        return _context.Set<CourseReservation>()
            .Any(r => r.Appointment == Appointment && r.StudentId == id);
    }

}
