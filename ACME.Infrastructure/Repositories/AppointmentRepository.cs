using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Core.Results;
using ACME.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Infrastructure.Repositories
{
    public class AppointmentRepository(AppDBContext dBContext) : IAppointmentRepository
    {
        public async Task<List<GetAppointmentsResult>> GetAppointments(GetAppointmentsRequest getAppointmentsRequest)
        {
            var paramInitialDate = new SqlParameter("@paramInitialDate", getAppointmentsRequest.InitialDate.HasValue ? getAppointmentsRequest.InitialDate : DBNull.Value);
            var paramFinalDate = new SqlParameter("@paramFinalDate", getAppointmentsRequest.FinalDate.HasValue ? getAppointmentsRequest.FinalDate : DBNull.Value);
            var paramPatientId = new SqlParameter("@paramPatientId", getAppointmentsRequest.PatientId.HasValue ? getAppointmentsRequest.PatientId : DBNull.Value);
            var paramStatus = new SqlParameter("@paramStatus", getAppointmentsRequest.Status.HasValue ? getAppointmentsRequest.Status : DBNull.Value);

            var appointmens = await dBContext.AppointmentsResult.FromSqlRaw("EXEC getAppointments @paramInitialDate, @paramFinalDate, @paramPatientId, @paramStatus", new object[] { paramInitialDate, paramFinalDate, paramPatientId, paramStatus })
                .ToListAsync();

            return appointmens;
        }

        public async Task<Appointment> Insert(Appointment appointment)
        {
            dBContext.Appointments.Add(appointment);
            await dBContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            var appointment = await dBContext.Appointments.FindAsync(id);
            return appointment;
        }

        public bool AppointmentExists(int id) => dBContext.Appointments.Any(e => e.AppointmentId == id);

        public async Task<Appointment> Update(Appointment appointment)
        {
            dBContext.Entry(appointment).State = EntityState.Modified;

            await dBContext.SaveChangesAsync();
            return appointment;
        }
    }
}
