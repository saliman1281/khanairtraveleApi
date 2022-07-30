using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.VisaService.VisaInstalmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Entities.VisaModel.VisaInstalment;

namespace KHANAIRSERVICEAPI.Controllers.VisaControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaInstalmentController : ControllerBase
    {
        private readonly IVisaInstalmentService _visaInstalmentService;
        public VisaInstalmentController(IVisaInstalmentService visaInstalmentService)
        {
            _visaInstalmentService = visaInstalmentService;
        }
        [HttpPost("AddVisaInstalment")]
        public async Task<IActionResult> AddVisaInstalment(VisaInstalmentRequest request)
        {
            var response = await _visaInstalmentService.AddVisaInstalment(request);

            return Ok(response);
        }
        [HttpPost("GetVisaInstalment")]
        public async Task<IActionResult> GetVisaInstalment(VisaInstalmentRequest request)
        {
            var response = await _visaInstalmentService.GetVisaInstalment(request);

            return Ok(response);
        }
    }
}
