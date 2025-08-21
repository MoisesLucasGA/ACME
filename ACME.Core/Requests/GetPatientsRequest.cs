using ACME.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Core.Requests
{
    public class GetPatientsRequest
    {
        public string? Search { get; set; }
        public PatientStatusEnum? Status { get; set; }
    }
}
