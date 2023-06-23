using AutoMapper;
using italk.BL.Dtos.ReservationDto;
using italk.DAL.Data.Models;
using italk.DAL.UnitOfWork;


namespace italk.BL.Managers.ReservationManager
{
    public class ReservationManager : IReservationManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<ReservationDto> GetReservationsForStudent(int id)
        {
            IQueryable<Reservation> reservations = _unitOfWork.ReservationRepo.GetReservationsForStudent(id);
            return _mapper.Map<List<ReservationDto>>(reservations);
        }


        public List<ReservationDto> GetReservationsForInstructor(int id)
        {
            IQueryable<Reservation> reservations = _unitOfWork.ReservationRepo.GetReservationsForInstructor(id);
            return _mapper.Map<List<ReservationDto>>(reservations);
        }

        public bool CheckAppointment(AddReservationDto addReservationDto)
        {
            return _unitOfWork.ReservationRepo.CheckAppointment(addReservationDto.Appointment , addReservationDto.StudentId);
        }
        public int Add(AddReservationDto addReservationDto)
        {
            var reservation = _mapper.Map<Reservation>(addReservationDto);
            _unitOfWork.ReservationRepo.Add(reservation);
            _unitOfWork.SaveChanges();
            return reservation.StudentId;
        }
    }
}
