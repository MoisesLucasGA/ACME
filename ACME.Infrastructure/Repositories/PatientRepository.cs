using ACME.Core.Models;
using ACME.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Infrastructure.Repositories
{
    public class PatientRepository(AppDBContext dBContext) : IPatientRepository
    {
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await dBContext.Patients.ToListAsync();
        }
    }
}
