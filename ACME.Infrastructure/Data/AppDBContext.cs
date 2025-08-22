using ACME.Core.Models;
using ACME.Core.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Infrastructure.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<GetAppointmentsResult> AppointmentsResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GetAppointmentsResult>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null); // prevents migrations from creating a table or view
            });
            //modelBuilder.Ignore<GetAppointmentsResult>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
