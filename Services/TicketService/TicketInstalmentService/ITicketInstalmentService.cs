using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.TicketModel.TicketInstalmentModel.TicketInstalment;

namespace Services.TicketService.TicketInstalmentService
{
    public interface ITicketInstalmentService
    {
        Task<string> AddTicketInstalmentDetail(TicketInstalmentRequest ticketInstalmentRequest);
        Task<List<TicketInstalmentResponse>> GetTicketInstalmentDetail(TicketInstalmentRequest ticketInstalmentRequest);
    }
}
