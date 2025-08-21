using ACME.Core.Models;

namespace ACME.Application.Services
{
    public interface IPatientService
    {
        public Task<IEnumerable<Patient>> GetPatients();
    }
}