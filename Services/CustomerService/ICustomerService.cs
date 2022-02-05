using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.Customer;

namespace Services.CustomerService
{
   public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetAllCustomer(string customerCNIC);

        Task<CustomerResponse> GetCustomer(string custId);

        Task<string> DeleteCustomer(string custId);

        Task<string> CustomerDuplicate(string custId);

        Task<string> UpdateCustomer(CustomerRequest request);

        Task<string> AddCustomer(CustomerRequest request);
    }
}
