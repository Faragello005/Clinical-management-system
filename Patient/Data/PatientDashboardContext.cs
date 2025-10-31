using Microsoft.EntityFrameworkCore;
using PatientDashboardAPI.Models;
using System.Collections.Generic;

namespace PatientDashboardAPI.Data
{
    public class PatientDashboardContext : DbContext
    {
        public PatientDashboardContext(DbContextOptions<PatientDashboardContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
    }
}
