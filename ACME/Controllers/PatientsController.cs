using ACME.Application.Services;
using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Core.Results;
using ACME.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ACME.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPatientService _iPatientService;

        public PatientsController(AppDBContext context, IPatientService iPatientService)
        {
            _context = context;
            _iPatientService = iPatientService;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients([FromQuery] GetPatientsRequest getPatientsRequest)
        {
            IEnumerable<Patient> patients = await _iPatientService.GetPatients(getPatientsRequest);

            BaseResult result = new BaseResult()
            {
                code = 200,
                data = patients
            };

            return Ok(result);
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, [FromBody] Patient patient)
        {
            var response = await _iPatientService.Update(id, patient);

            BaseResult result = new BaseResult()
            {
                code = 200,
                data = response
            };

            return Ok(result);
        }

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient([FromBody] Patient patient)
        {
            var response = await _iPatientService.save(patient);

            BaseResult result = new BaseResult()
            {
                code = 200,
                data = response
            };

            return Ok(result);
        }

        [HttpPut("inactivate")]
        public async Task<IActionResult> Inactivate([FromQuery] int id)
        {
            var response = await _iPatientService.Inactivate(id);

            BaseResult result = new BaseResult()
            {
                code = 200,
                data = response
            };

            return Ok(result);
        }
    }
}
