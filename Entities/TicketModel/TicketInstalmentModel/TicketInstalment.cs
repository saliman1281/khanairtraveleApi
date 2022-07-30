using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.TicketModel.TicketInstalmentModel
{
    public class TicketInstalment
    {
        public class TicketInstalmentRequest
        {
            public int ticketInstalmentId { get; set; }
            public string ticketNumber { get; set; }
            public decimal ticketInstalmentAmount { get; set; }
            public string modifiedBy { get; set; }
            public string option { get; set; }
        }
        public class TicketInstalmentResponse
        {
            public int ticketInstalmentId { get; set; }
            public string ticketNumber { get; set; }
            public decimal ticketInstalmentAmount { get; set; }
            public DateTime createDate { get; set; }
        }
    }
}
