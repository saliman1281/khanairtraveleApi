using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.TicketModel.Ticket;

namespace Services.TicketService.TicketInfoService
{
    public interface ITicketInfoService
    {
        Task<string> AddticketInfo(TicketInfoRequest request);
        Task<string> UpdateTicketInfo(TicketInfoRequest request);
        Task<List<TicketInfoResponse>> GetAllTicketOfCustomer(string customerCNIC);
        Task<TicketInfoResponse> GetTicketInfo(string ticketNmbr);
        Task<string> DeleteTicketInfo(string ticketNum);
    }
}
