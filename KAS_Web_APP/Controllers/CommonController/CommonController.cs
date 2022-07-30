using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Entities.CommonModel.CommonModel;

namespace KHANAIRSERVICEAPI.Controllers.CommonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        [HttpGet("GetCommonData")]
        public async Task<IActionResult> GetCommonData()
        {
            string custId = "0";
            var response = await _commonService.GetCommonData(custId);
            await CreateDBBackUp();
            return Ok(response);
        }
        [HttpGet("GetRepresentativeList")]
        public async Task<IActionResult> GetRepresentativeList(int dealerId)
        {
            var response = await _commonService.GetRepresentativeList(dealerId);

            return Ok(response);
        }
        [HttpPost("AddRefInfo")]
        public async Task<IActionResult> AddRefInfo(RepresentativeRequest request)
        {
            var response = await _commonService.AddRefInfo(request);

            return Ok(response);
        }
        [HttpPost("AddAirLine")]
        public async Task<IActionResult> AddAirLine(AirLineRequest request)
        {
            var response = await _commonService.AddAirLine(request);

            return Ok(response);
        }
        [HttpGet("GetAirLineList")]
        public async Task<IActionResult> GetAirLineList()
        {
            var response = await _commonService.GetAirLineList();

            return Ok(response);
        }
        [HttpPost("AddTicketType")]
        public async Task<IActionResult> AddTicketType(TicketTypeRequest request)
        {
            var response = await _commonService.AddTicketType(request);

            return Ok(response);
        }
        [HttpGet("GetTicketTypeList")]
        public async Task<IActionResult> GetTicketTypeList()
        {
            var response = await _commonService.GetTicketTypeList();

            return Ok(response);
        }
        [HttpPost("AddVisaType")]
        public async Task<IActionResult> AddVisaType(VisaTypeRequest request)
        {
            var response = await _commonService.AddVisaType(request);

            return Ok(response);
        }
        [HttpGet("GetVisaTypeList")]
        public async Task<IActionResult> GetVisaTypeList()
        {
            var response = await _commonService.GetVisaTypeList();

            return Ok(response);
        }
        [HttpGet("CreateDBBackUp")]
        public async Task<IActionResult> CreateDBBackUp()
        {
            var response = await _commonService.CreateDBBackUp();

            return Ok(response);
        }
    }
}
