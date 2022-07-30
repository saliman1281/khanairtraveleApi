using Microsoft.AspNetCore.Mvc;
using Services.CustomerService;
using static Entities.Customer;

namespace KHANAIRSERVICEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var currentUser = "API Running ......";
            return Ok(currentUser);

        }
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            string customerCNIC = "0";
            var response = await _customerService.GetAllCustomer(customerCNIC);

            return Ok(response);
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(string custId)
        {
            var response = await _customerService.GetCustomer(custId);

            return Ok(response);
        }

        [HttpGet("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(string custId)
        {
            var response = await _customerService.DeleteCustomer(custId);

            return Ok(response);
        }

        [HttpGet("CustomerDuplicate")]
        public async Task<IActionResult> CustomerDuplicate(string custId)
        {
            var response = await _customerService.CustomerDuplicate(custId);

            return Ok(response);
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerRequest request)
        {
            var response = await _customerService.AddCustomer(request);

            return Ok(response);
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerRequest request)
        {
            var response = await _customerService.UpdateCustomer(request);

            return Ok(response);
        }

    }


}
