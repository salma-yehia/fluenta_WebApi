using italk.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;namespace italk.DAL.Data.Context
{
    public class Context:IdentityDbContext<BaseModel,IdentityRole<int>,int>
    {
        public DbSet<Language> Languages => Set<Language>(); 
        public DbSet<Reservation> Resrvation => Set<Reservation>();
        public DbSet<CourseReservation> CourseResrvation => Set<CourseReservation>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses=> Set<Course>();
        public DbSet<Questions> Questions => Set<Questions>();
        public DbSet<Options> Options => Set<Options>();

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>().HasKey(e => new { e.StudentId, e.InstructorId });
            modelBuilder.Entity<CourseReservation>().HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Reservation>().HasOne(t => t.Student).WithMany(t => t.Resrvations)
                .HasForeignKey(t => t.StudentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>().HasOne(t => t.Instructor).WithMany(t => t.Resrvations)
               .HasForeignKey(t => t.InstructorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Instructor>().HasOne(t => t.Language).WithMany(t => t.instructors)
                    .HasForeignKey(t => t.LanguageId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CourseReservation>().HasOne(t => t.Course).WithMany(t => t.CrsReservations)
                .HasForeignKey(t => t.CourseId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Course>().HasOne(t => t.Language).WithMany(t => t.Courses)
                .HasForeignKey(t => t.LanguageId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CourseReservation>().HasOne(t => t.Student).WithMany(t => t.CrsReservations)
                .HasForeignKey(t => t.StudentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Course>().HasOne(t => t.Instructor).WithMany(t => t.Courses)
                .HasForeignKey(t => t.InstructorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Options>().HasOne(t => t.Questions).WithMany(t => t.Options)
                .HasForeignKey(t => t.QuestionId).OnDelete(DeleteBehavior.NoAction);
        }


    }
}
