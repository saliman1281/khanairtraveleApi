using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.CommonModel
{
    public class CommonModel
    {
        public class CommonDataRequest
        {
        }
        public class DealerDataResponse
        {
            public int dealerId { get; set; }
            public string dealerName { get; set; }
        }
        public class RepresentativeResponse
        {
            public int representId { get; set; }
            public int dealerId { get; set; }
            public string representativeName { get; set; }=String.Empty;
        }
        public class RepresentativeRequest
        {
            public int DealerId { get; set; }
            public string RepName { get; set; }
            public string modifiedBy { get; set; }
        } 
        public class AirLineRequest
        {
            public string AirLineFullName { get; set; }
            public string AirLineABR { get; set; }
            public string modifiedBy { get; set; }
        }
        public class AirLineResponse
        {
            public int AirLineId { get; set; }
            public string AirLineFullName { get; set; }
            public string AirLineABR { get; set; }
        }
        public class TicketTypeRequest
        {
            public int TicketId { get; set; }
            public string TicketTypeName { get; set; }
            public string modifiedBy { get; set; }
        }
        public class TicketTypeResponse
        {
            public int TicketId { get; set; }
            public string TicketTypeName { get; set; }
        }
        public class VisaTypeRequest
        {
            public int VisaTypeId { get; set; }
            public string VisaTypeName { get; set; }
            public string modifiedBy { get; set; }
        }
        public class VisaTypeResponse
        {
            public int VisaTypeId { get; set; }
            public string VisaTypeName { get; set; }
        }
    }
}