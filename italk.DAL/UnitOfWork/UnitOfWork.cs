using italk.DAL.Data.Context;
using italk.DAL.Repos.Instructors;
using italk.DAL.Repos.Languages;
using italk.DAL.Repos.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILanguageRepo LanguageRepo { get; }
        public IReservationRepo ReservationRepo { get; }
        public IInstructorRepo InstructorRepo { get; }


        private readonly Context _context;

        public UnitOfWork(ILanguageRepo languageRepoFromIoC,
            IReservationRepo reservationRepoFromIoC, IInstructorRepo instructorRepoFromIoC,
            Context context)
        {
            LanguageRepo = languageRepoFromIoC;
            ReservationRepo = reservationRepoFromIoC;
            InstructorRepo = instructorRepoFromIoC;
            _context = context;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
