using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Core.Results;

namespace ACME.Infrastructure.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<GetAppointmentsResult>> GetAppointments(GetAppointmentsRequest getAppointmentsRequest);
        Task<Appointment> Insert(Appointment appointment);
        Task<Appointment> Update(Appointment appointment);
        bool AppointmentExists(int id);
        Task<Appointment> GetAppointmentById(int id);
    }
}