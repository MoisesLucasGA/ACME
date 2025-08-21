using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetPatients(GetPatientsRequest getPatientsRequest)
        {
            var patients = await _patientRepository.GetPatients(getPatientsRequest);

            return patients;
        }

        public async Task<Patient> save(Patient patient)
        {
            GetPatientsRequest req = new GetPatientsRequest
            {
                Search = patient.CPF,
                Status = null
            };
            var existingPatient = await _patientRepository.GetPatients(req);

            if (!existingPatient.IsNullOrEmpty())
            {
                throw new Exception("Paciente inválido");
            }

            return await _patientRepository.Insert(patient);
        }

        public async Task<Patient> Update(int id, Patient patient)
        {
            if (!_patientRepository.PatientExists(id))
            {
                throw new Exception("Paciente não encontrado");
            }

            return await _patientRepository.Update(patient);
        }

        public async Task<Patient> Inactivate(int id)
        {

            var patient = await _patientRepository.GetPatientById(id) ?? throw new Exception("Paciente não encontrado");

            patient.Status = Core.Enums.PatientStatusEnum.Inactive;

            return await _patientRepository.Update(patient);
        }
    }
}
