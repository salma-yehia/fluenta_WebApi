using italk.BL.Dtos.ReservationDto;

namespace italk.BL;
public interface ICourseReservationManager
{
    int Add(AddCourseReservationDto addCrsReservationDto);
    List<CourseReservationDto> GetReservationsForCourse(int id);
    List<CourseReservationDto> GetReservationsForStudent(int id);
    bool CheckAppointment(AddCourseReservationDto addreservationDto);


}
