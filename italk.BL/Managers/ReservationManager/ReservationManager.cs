using AutoMapper;
using italk.BL.Dots;
using italk.BL.Dtos.ReservationDto;
using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;
using italk.DAL.Repos.Languages;
using italk.DAL.Repos.Reservations;
using italk.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static italk.BL.Dots.InstructorRegisterDto;

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
