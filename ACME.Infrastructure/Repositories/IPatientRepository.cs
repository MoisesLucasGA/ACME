using ACME.Core.Models;

namespace ACME.Infrastructure.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
    }
}