using Microsoft.AspNetCore.Mvc;
using Services.CommonService;

namespace KAS_Web_APP.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly ICommonService _commonService;
        public DashboardController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        [HttpGet("GetDashboardData")]
        public async Task<IActionResult> Index()
        {

            var response = await _commonService.CreateDBBackUp();

            return Ok(response);
        }
    }
}
