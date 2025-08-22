using ACME.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Core.Results
{
    [NotMapped]
    public class GetAppointmentsResult
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public int PatientId { get; set; }
        public required string Name { get; set; }
        public required string CPF { get; set; }
    }
}