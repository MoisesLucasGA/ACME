using ACME.Core.Models;
using ACME.Core.Requests;

namespace ACME.Infrastructure.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetPatients(GetPatientsRequest getPatientsRequest);
        Task<Patient> Insert(Patient patient);
        bool PatientExists(int id);
        Task<Patient> Update(Patient patient);
        Task<Patient> GetPatientById(int id);
        Task<bool> Inactivate(Patient patient);
    }
}