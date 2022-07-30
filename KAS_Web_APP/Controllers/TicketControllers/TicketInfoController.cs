using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.TicketService.TicketInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Entities.TicketModel.Ticket;

namespace KHANAIRSERVICEAPI.Controllers.TicketControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketInfoController : ControllerBase
    {
        private readonly ITicketInfoService _ticketInfoService;
        public TicketInfoController(ITicketInfoService ticketInfoService)
        {
            _ticketInfoService = ticketInfoService;
        }

        [HttpPost("AddticketInfo")]
        public async Task<IActionResult> AddticketInfo(TicketInfoRequest request)
        {
            var response = await _ticketInfoService.AddticketInfo(request);

            return Ok(response);
        }

        [HttpPost("UpdateTicketInfo")]
        public async Task<IActionResult> UpdateTicketInfo(TicketInfoRequest request)
        {
            var response = await _ticketInfoService.UpdateTicketInfo(request);

            return Ok(response);
        }

        [HttpGet("GetAllTicketOfCustomer")]
        public async Task<IActionResult> GetAllTicketOfCustomer(string customerCNIC)
        {
            var response = await _ticketInfoService.GetAllTicketOfCustomer(customerCNIC);

            return Ok(response);
        }

        [HttpGet("GetTicketInfo")]
        public async Task<IActionResult> GetTicketInfo(string ticketNumber)
        {
            var response = await _ticketInfoService.GetTicketInfo(ticketNumber);

            return Ok(response);
        }

        [HttpGet("DeleteTicketInfo")]
        public async Task<IActionResult> DeleteTicketInfo(string ticketNumber)
        {
            var response = await _ticketInfoService.DeleteTicketInfo(ticketNumber);

            return Ok(response);
        }
    }
}
