﻿using italk.DAL.Data.Context;
using italk.DAL.Repos.Question;
using italk.DAL.Repos.Instructors;
using italk.DAL.Repos.Languages;
using italk.DAL.Repos.Reservations;

namespace italk.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILanguageRepo LanguageRepo { get; }
        public IReservationRepo ReservationRepo { get; }
        public ICourseReservationRepo CourseReservationRepo { get; }
        public IInstructorRepo InstructorRepo { get; }
        public IQuestionsRepo QuestionsRepo { get; }
        public ICourseRepo CourseRepo { get; set; }  


        private readonly Context _context;

        public UnitOfWork(ILanguageRepo languageRepoFromIoC,
            IReservationRepo reservationRepoFromIoC, IInstructorRepo instructorRepoFromIoC, ICourseRepo courseRepoFromIoC, ICourseReservationRepo courseReservationRepoFromIoC,
            Context context, IQuestionsRepo questionsRepoFromIoc)
        {
            LanguageRepo = languageRepoFromIoC;
            ReservationRepo = reservationRepoFromIoC;
            CourseReservationRepo = courseReservationRepoFromIoC;
            InstructorRepo = instructorRepoFromIoC;
            CourseRepo= courseRepoFromIoC;
            _context = context;
            QuestionsRepo = questionsRepoFromIoc;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
