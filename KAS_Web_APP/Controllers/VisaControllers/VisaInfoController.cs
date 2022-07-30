using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.VisaService.VisaInformationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Entities.VisaModel.VisaInformation;

namespace KHANAIRSERVICEAPI.Controllers.VisaControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaInfoController : ControllerBase
    {
        private readonly IVisaInfoService _visaInfoService;
        public  VisaInfoController(IVisaInfoService visaInfoService)
        {
            _visaInfoService = visaInfoService;
        }
        [HttpPost("AddVisaDetail")]
        public async Task<IActionResult> AddVisaDetail(VisaInfoRequest request)
        {
            var response = await _visaInfoService.AddVisaDetail(request);

            return Ok(response);
        }
        [HttpPost("GetVisaDetail")]
        public async Task<IActionResult> GetVisaDetail(VisaInfoRequest request)
        {
            var response = await _visaInfoService.GetVisaDetail(request);

            return Ok(response);
        }
        [HttpGet("GetVisaInfo")]
        public async Task<IActionResult> GetVisaInfo(string visaNo)
        {
            var response = await _visaInfoService.GetVisaInfo(visaNo);

            return Ok(response);
        }
    }
}
