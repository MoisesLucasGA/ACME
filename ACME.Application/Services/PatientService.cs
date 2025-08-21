using ACME.Core.Models;
using ACME.Infrastructure.Repositories;
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

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _patientRepository.GetPatients();

            if (patients == null) {
                throw new Exception("No patients found");
            }

            return patients;
        }
    }
}
