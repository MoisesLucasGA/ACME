using ACME.Application.Services;
using ACME.Core.Models;
using ACME.Core.Requests;
using ACME.Core.Results;
using ACME.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(AppDBContext context, IAppointmentService appointmentService)
        {
            _context = context;
            _appointmentService = appointmentService;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAppointmentsResult>>> GetAppointments([FromQuery] GetAppointmentsRequest getAppointmentsRequest)
        {
            var response = await _appointmentService.GetAppointments(getAppointmentsRequest);

            BaseResult result = new BaseResult()
            {
                code = 200,
                data = response
            };

            return Ok(result);
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment([FromBody] Appointment appointment)
        {
            var response = await _appointmentService.Save(appointment);

            BaseResult result = new BaseResult()
            {
                code = 200,
                data = response
            };

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, [FromBody] Appointment appointment)
        {
            var response = await _appointmentService.Update(id, appointment);

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
            var response = await _appointmentService.Inactivate(id);

            BaseResult result = new BaseResult()
            {
                code = 200,
                data = response
            };

            return Ok(result);
        }
    }
}
