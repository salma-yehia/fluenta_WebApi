using italk.DAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using italk.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace italk.DAL.Repos.Reservations
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly Context _context;

        public ReservationRepo(Context context)
        {
            _context = context;
        }
        public void Add(Reservation reservation)
        {
            _context.Set<Reservation>().Add(reservation);
        }
        public IQueryable<Reservation> GetReservationsForStudent(int id)
        {
            return _context.Set<Reservation>().Include(i => i.Instructor).Where(r => r.StudentId == id);
        }

        public IQueryable<Reservation> GetReservationsForInstructor(int id)
        {
            return _context.Set<Reservation>().Include(s => s.Student).Where(r => r.InstructorId == id);
        }
        public bool CheckAppointment(DateTime Appointment, int id)
        {
            return _context.Set<Reservation>()
                .Any(r => r.Appointment== Appointment && r.StudentId == id);
        }
    }
}
