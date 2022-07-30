using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DealerService.DealerInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Entities.DealerModel.DealerInfo;

namespace KHANAIRSERVICEAPI.Controllers.DealerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerInfoController : ControllerBase
    {
        private readonly IDealerInfoService _dealerInfoService;
        public DealerInfoController(IDealerInfoService dealerInfoService)
        {
            _dealerInfoService = dealerInfoService;
        }
        [HttpGet("GetAllDealer")]
        public async Task<IActionResult> GetAllDealer()
        {
            string customerCNIC = "0";
            var response = await _dealerInfoService.GetAllDealer(customerCNIC);

            return Ok(response);
        }

        [HttpGet("GetDealerInfo")]
        public async Task<IActionResult> GetDealerInfo(int dealerId)
        {
            var response = await _dealerInfoService.GetDealerInfo(dealerId);

            return Ok(response);
        }

        [HttpPost("AddDealerInfo")]
        public async Task<IActionResult> AddDealerInfo(DealerInfoRequest request)
        {
            var response = await _dealerInfoService.AddDealerInfo(request);

            return Ok(response);
        }

        [HttpPost("UpdateDealerInfo")]
        public async Task<IActionResult> UpdateDealerInfo(DealerInfoRequest request)
        {
            var response = await _dealerInfoService.UpdateDealerInfo(request);

            return Ok(response);
        }
    }
}
