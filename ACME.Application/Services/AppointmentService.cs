using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Core.Enums;
using ACME.Infrastructure.Repositories;
using ACME.Core.Results;

namespace ACME.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        public async Task<List<GetAppointmentsResult>> GetAppointments(GetAppointmentsRequest getAppointmentsRequest)
        {
            if ((getAppointmentsRequest.InitialDate.HasValue && !getAppointmentsRequest.FinalDate.HasValue) 
                || (!getAppointmentsRequest.InitialDate.HasValue && getAppointmentsRequest.FinalDate.HasValue))
            {
                throw new Exception("Datas inválidas");
            }
            if (getAppointmentsRequest.InitialDate > getAppointmentsRequest.FinalDate)
            {
                throw new Exception("Data inicial deve ser menor que data final");
            }

            var appointments = await _appointmentRepository.GetAppointments(getAppointmentsRequest);

            return appointments;
        }

        public async Task<Appointment> Save(Appointment appointment)
        {
            
            var validPatient = await _patientRepository.GetPatientById(appointment.PatientId);

            if (validPatient == null || validPatient.Status == Core.Enums.PatientStatusEnum.Inactive)
            {
                throw new Exception("Paciente inativo");
            }
            if(appointment.Date > System.DateTime.Now)
            {
                throw new Exception("Data deve ser menor que a data atual");
            }

            return await _appointmentRepository.Insert(appointment);
        }

        public async Task<Appointment> Update(int id, Appointment appointment)
        {
            if (!_appointmentRepository.AppointmentExists(id))
            {
                throw new Exception("Atendimento não encontrado");
            }
            if (appointment.Date > System.DateTime.Now)
            {
                throw new Exception("Data deve ser menor que a data atual");
            }

            return await _appointmentRepository.Update(appointment);
        }

        public async Task<Appointment> Inactivate(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id) ?? throw new Exception("Atendimento não encontrado");
            appointment.Status = appointment.Status == AppointmentStatusEnum.Inactive 
                ? AppointmentStatusEnum.Active 
                : AppointmentStatusEnum.Inactive;

            return await _appointmentRepository.Update(appointment);
        }

    }
}
