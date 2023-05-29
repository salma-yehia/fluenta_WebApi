﻿using italk.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace italk.DAL.Data.Context
{
    public class Context:IdentityDbContext<BaseModel,IdentityRole<int>,int>
    {
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Reservation> Resrvation => Set<Reservation>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Student> Students => Set<Student>();
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>().HasKey(e => new {e.StudentId , e.InstructorId });

            modelBuilder.Entity<Reservation>().HasOne(t => t.Student).WithMany(t => t.Resrvations)
                .HasForeignKey(t => t.StudentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>().HasOne(t => t.Instructor).WithMany(t => t.Resrvations)
               .HasForeignKey(t => t.InstructorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Instructor>().HasOne(t => t.Language).WithMany(t => t.instructors)
               .HasForeignKey(t => t.LanguageId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
