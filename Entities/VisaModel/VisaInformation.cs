using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.VisaModel
{
    public class VisaInformation
    {
        public class VisaInfoRequest
        {
            public string visaNumber { get; set; }
            public string customerCnic { get; set; }
            public int dealerId { get; set; }
            public int representId { get; set; }
            public int visaTypeId { get; set; }
            public string visaCountry { get; set; }
            public decimal visaCostPrice { get; set; }
            public decimal visaRetailPrice { get; set; }
            public decimal visaPaidAmount { get; set; }
            public string modifiedBy { get; set; }

            public string option { get; set; }
        }
        public class VisaInfoResponse
        {
            public int visaId { get; set; }
            public string visaNumber { get; set; }
            public string customerCnic { get; set; }
            public int dealerId { get; set; }
            public int representId { get; set; }
            public string visaType { get; set; }
            public int visaTypeId { get; set; }
            public string visaCountry { get; set; }
            public decimal visaCostPrice { get; set; }
            public decimal visaRetailPrice { get; set; }
            public decimal visaPaidAmount { get; set; }
            public DateTime createDate { get; set; }
            public string modifiedBy { get; set; }
        }
    }
}
