using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.TicketModel
{
    public class Ticket
    {
        public class TicketInfoRequest
        {
            //public int tickitId { get; set; }
            public int customerId { get; set; }
            public string customerCNIC { get; set; }
            public string ticketNumber { get; set; }
            public string ticketPNR { get; set; }
            public string airlineType { get; set; }
            public string fromLocation { get; set; }
            public string toLocation { get; set; }
            public string bookingDate { get; set; }
            public decimal ticketCost { get; set; }
            public decimal ticketRetail { get; set; }
            public decimal ticketAmountPaid { get; set; }
            public string ticketType { get; set; }
            public string returnFrom { get; set; }
            public string returnTo { get; set; }
            public string returnDate { get; set; }
            public string passportImage { get; set; }
            public string modifiedBy { get; set; }
            //  public DateTime createdDate { get; set; }
            // public DateTime modifiedDate { get; set; }
}
        public class TicketInfoResponse
        {
          //  public int tickitId { get; set; }
            public int customerId { get; set; }

            public string customerCNIC { get; set; }
            public string ticketNumber { get; set; }
            public string ticketPNR { get; set; }
            public string airlineType { get; set; }
            public string fromLocation { get; set; }
            public string toLocation { get; set; }
            public DateTime bookingDate { get; set; }
           // public string entrydate { get; set; }
            public decimal ticketCost { get; set; }
            public decimal ticketRetail { get; set; }
            public decimal ticketAmountPaid { get; set; }
            public string ticketType { get; set; }
            public string returnFrom { get; set; }
            public string returnTo { get; set; }
            public DateTime returnDate { get; set; }
            public string passportImage { get; set; }
          //  public string createdDate { get; set; }
           // public string modifiedDate { get; set; }
           // public string modifiedBy { get; set; }
        }

    }
}
