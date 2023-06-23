using italk.BL;
using Microsoft.AspNetCore.Mvc;

namespace italk.APIs;

[Route("api/[controller]")]
[ApiController]
public class CourseReservationController : ControllerBase
{
    private readonly ICourseReservationManager _CoursereservationManager;

    public CourseReservationController(ICourseReservationManager reservationManager)
    {
        _CoursereservationManager = reservationManager;
    }
    [HttpPost("AddCrsReservation")]
    public int AddCrsReservation(AddCourseReservationDto addReservationDto)
    {
        return _CoursereservationManager.Add(addReservationDto);
    }

    [HttpPost("CheckCrsAppointment")]
    public bool CheckCrsAppointment(AddCourseReservationDto addReservationDto)
    {
        return _CoursereservationManager.CheckAppointment(addReservationDto);
    }

    [HttpGet("GetReservationsForCourse/{CrsId}")]
    public ActionResult<List<CourseReservationDto>> GetReservationsForCourse(int CrsId)
    {
        return _CoursereservationManager.GetReservationsForCourse(CrsId);

    }
    [HttpGet("GetReservationsForStudent/{StdId}")]
    public ActionResult<List<CourseReservationDto>> GetReservationsForStudent(int StdId)
    {
        return _CoursereservationManager.GetReservationsForStudent(StdId);
    }
}
