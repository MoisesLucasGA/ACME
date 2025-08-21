using ACME.Core.Enums;

namespace ACME.Core.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public required string Description { get; set; }
        public AppointmentStatusEnum Status { get; set; }
    }
}
