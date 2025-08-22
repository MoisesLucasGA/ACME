using ACME.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Core.Requests
{
    public class GetAppointmentsRequest
    {
        public int? PatientId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public AppointmentStatusEnum? Status { get; set; }
    }
}
