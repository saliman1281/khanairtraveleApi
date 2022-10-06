using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.CommonModel
{
    public class CommonModel
    {
        public class CommonDataRequest
        {
            [NotMapped]
            public bool IsUpdate { get; set; }
        }
        public class DealerDataResponse
        {
            public int dealerId { get; set; }
            public string? dealerName { get; set; }
        }
        public class RepresentativeResponse
        {
            public int representId { get; set; }
            public int dealerId { get; set; }
            public string representativeName { get; set; } = String.Empty;
        }
        [Table("RepresentativeInformation")]
        public class RepresentativeRequest: CommonDataRequest
        {
            [Key]
            public int representId { get; set; }
            public int dealerId { get; set; }
            public string? representativeName { get; set; }
            public string? modifiedBy { get; set; }
        }
        [Table("AirLineInfo")]
        public class AirLineRequest : CommonDataRequest
        {
            [Key]
            public int AirLineId { get; set; }
            public string? AirLineFullName { get; set; }
            public string? AirLineABR { get; set; }
            public string? modifiedBy { get; set; }
        }
        public class AirLineResponse
        {
            public int AirLineId { get; set; }
            public string? AirLineFullName { get; set; }
            public string? AirLineABR { get; set; }
        }
        [Table("TicketTypeInfo")]
        public class TicketTypeRequest : CommonDataRequest
        {
            [Key]
            public int TicketId { get; set; }
            public string? TicketTypeName { get; set; }
            public string? modifiedBy { get; set; }
        }
        public class TicketTypeResponse
        {
            public int TicketId { get; set; }
            public string? TicketTypeName { get; set; }
        }
        [Table("VisaTypeInfo")]
        public class VisaTypeRequest : CommonDataRequest
        {
            public int VisaTypeId { get; set; }
            public string? VisaTypeName { get; set; }
            public string? modifiedBy { get; set; }
        }
        public class VisaTypeResponse
        {
            public int VisaTypeId { get; set; }
            public string? VisaTypeName { get; set; }
        }
    }
}