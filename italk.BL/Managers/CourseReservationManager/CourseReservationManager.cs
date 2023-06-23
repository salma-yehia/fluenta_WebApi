using AutoMapper;
using italk.BL.Dtos.ReservationDto;
using italk.DAL;
using italk.DAL.Data.Models;
using italk.DAL.UnitOfWork;

namespace italk.BL;
public  class CourseReservationManager:ICourseReservationManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseReservationManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public int Add(AddCourseReservationDto addReservationDto)
    {
        CourseReservation Crsreservation = _mapper.Map<CourseReservation>(addReservationDto);
        _unitOfWork.CourseReservationRepo.Add(Crsreservation);
        _unitOfWork.SaveChanges();
        return Crsreservation.StudentId;
    }

    public List<CourseReservationDto> GetReservationsForCourse(int Crsid)
    {
        IQueryable<CourseReservation> reservations = _unitOfWork.CourseReservationRepo.GetReservationsForCourse(Crsid);
        return _mapper.Map<List<CourseReservationDto>>(reservations);
    }

    public List<CourseReservationDto> GetReservationsForStudent(int Stdid)
    {
        IQueryable<CourseReservation> reservations = _unitOfWork.CourseReservationRepo.GetReservationsByStudent(Stdid);
        return _mapper.Map<List<CourseReservationDto>>(reservations);
    }
    public bool CheckAppointment(AddCourseReservationDto addreservationDto)
    {
        return _unitOfWork.CourseReservationRepo.CheckAppointment(addreservationDto.Appointment, addreservationDto.StudentId);
    }

}
