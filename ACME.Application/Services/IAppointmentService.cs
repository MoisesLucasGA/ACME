using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Core.Results;

namespace ACME.Application.Services
{
    public interface IAppointmentService
    {
        Task<List<GetAppointmentsResult>> GetAppointments(GetAppointmentsRequest getAppointmentsRequest);
        Task<Appointment> Save(Appointment appointment);
        Task<Appointment> Update(int id, Appointment appointment);
        Task<Appointment> Inactivate(int id);
    }
}