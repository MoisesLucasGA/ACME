using ACME.Core.Models;
using ACME.Core.Requests;

namespace ACME.Application.Services
{
    public interface IPatientService
    {
        public Task<IEnumerable<Patient>> GetPatients(GetPatientsRequest getPatientsRequest);
        public Task<Patient> save(Patient patient);
        public Task<Patient> Update(int id, Patient patient);
        Task<Patient> Inactivate(int id);
    }
}