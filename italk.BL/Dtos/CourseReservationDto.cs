﻿using italk.DAL.Data.Models;
using italk.DAL;

namespace italk.BL;

public class CourseReservationDto
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime Appointment { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
}
