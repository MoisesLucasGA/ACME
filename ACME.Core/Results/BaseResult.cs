using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Core.Results
{
    public class BaseResult
    {
        public int code { get; set; }
        public dynamic? data { get; set; }
        public string? message { get; set; }
    }
}
