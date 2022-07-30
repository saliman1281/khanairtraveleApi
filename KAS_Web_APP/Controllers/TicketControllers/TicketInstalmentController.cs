using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.TicketService.TicketInstalmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Entities.TicketModel.TicketInstalmentModel.TicketInstalment;

namespace KHANAIRSERVICEAPI.Controllers.TicketControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketInstalmentController : ControllerBase
    {
        private readonly ITicketInstalmentService _ticketInstalmentService;
        public TicketInstalmentController(ITicketInstalmentService ticketInstalmentService)
        {
            _ticketInstalmentService = ticketInstalmentService;
        }

        [HttpPost("AddTicketInstalmentDetail")]
        public async Task<IActionResult> AddTicketInstalmentDetail(TicketInstalmentRequest request)
        {
            var response = await _ticketInstalmentService.AddTicketInstalmentDetail(request);

            return Ok(response);
        }
        [HttpPost("GetTicketInstalmentDetail")]
        public async Task<IActionResult> GetTicketInstalmentDetail(TicketInstalmentRequest request)
        {
            var response = await _ticketInstalmentService.GetTicketInstalmentDetail(request);

            return Ok(response);
        }
    }
}
