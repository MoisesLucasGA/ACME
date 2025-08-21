using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ACME.Infrastructure.Repositories
{
    public class PatientRepository(AppDBContext dBContext) : IPatientRepository
    {
        public async Task<List<Patient>> GetPatients(GetPatientsRequest getPatientsRequest)
        {
            var paramSearch = new SqlParameter("@paramSearch", string.IsNullOrEmpty(getPatientsRequest.Search) ? DBNull.Value : getPatientsRequest.Search);
            var paramStatus = new SqlParameter("@paramStatus", getPatientsRequest.Status.HasValue ? getPatientsRequest.Status : DBNull.Value);

            var patients = await dBContext.Patients
                .FromSqlRaw("EXEC getPatients @paramSearch, @paramStatus", new object[] { paramSearch, paramStatus })
                .ToListAsync();
            return patients;
        }

        public async Task<Patient> Insert(Patient patient)
        {
            dBContext.Patients.Add(patient);
            await dBContext.SaveChangesAsync();
            return patient;
        }

        public bool PatientExists(int id) => dBContext.Patients.Any(e => e.PatientId == id);

        public async Task<Patient> Update(Patient patient)
        {
            dBContext.Entry(patient).State = EntityState.Modified;

            await dBContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await dBContext.Patients.FindAsync(id);
            return patient;
        }

        public async Task<bool> Inactivate(Patient patient)
        {

            dBContext.Entry(patient).State = EntityState.Modified;

            await dBContext.SaveChangesAsync();

            return true;

        }
    }
}
