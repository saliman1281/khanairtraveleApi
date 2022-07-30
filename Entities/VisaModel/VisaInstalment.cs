using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.VisaModel
{
    public class VisaInstalment
    {
        public class VisaInstalmentRequest
        {
            public int visaInstalmentId { get; set; }
            public string visaNumber { get; set; }
            public decimal visaInstalmentAmount { get; set; }
            public string modifiedBy { get; set; }
            public string option { get; set; }
        }
        public class VisaInstalmentResponse
        {
            public int visaInstalmentId { get; set; }
            public string visaNumber { get; set; }
            public decimal visaInstalmentAmount { get; set; }
            public DateTime createDate { get; set; }
            public string modifiedBy { get; set; }
        }
    }
}
