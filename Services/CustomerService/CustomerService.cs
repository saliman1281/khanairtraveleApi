using DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Entities.Customer;

namespace Services.CustomerService
{
    public class CustomerService: ICustomerService
    {

        private readonly IDBConnection _dbConnectionLogic;
        private readonly IListConverter _listConverter;
        public CustomerService(IDBConnection dbConnectionLogic, IListConverter listConverter)
        {
            _dbConnectionLogic = dbConnectionLogic;
            _listConverter = listConverter;
        }
        public async Task<List<CustomerResponse>> GetAllCustomer(string customerCNIC)
        {
            List<CustomerResponse> response = new List<CustomerResponse>();

            string spName = @"SP_GetAllCustomer";
           // var _customerCNIC = Convert.ToInt64(customerCNIC);

            Hashtable Param = new Hashtable
                {
                    { "@customerCNIC", customerCNIC },
                };

            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<CustomerResponse>(dataTable);
            }

            return response;
        }

        public async Task<CustomerResponse> GetCustomer(string custId)
        {
            CustomerResponse response = new CustomerResponse();

            string spName = @"SP_GetCustomer";
            // var _customerCNIC = Convert.ToInt64(customerCNIC);

            Hashtable Param = new Hashtable
                {
                    { "@customerCNIC", custId },
                };

            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.GetItem1<CustomerResponse>(dataTable.Rows[0]);
            }

            return response;
        }

        public async Task<string> DeleteCustomer(string custId)
        {

            string spName = @"SP_DeleteCustomer";

            Hashtable Param = new Hashtable
                {
                    { "@customerCNIC", custId },
                };
            string response = await _dbConnectionLogic.IUD(spName, Param);
            return response;
        }

        public async Task<string> CustomerDuplicate(string custId)
        {

            string spName = @"SP_CustomerDuplicate";
            string response = "";
            CustomerResponse cresponse = new CustomerResponse();
            Hashtable Param = new Hashtable
                {
                    { "@customerCNIC", custId },
                };
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
               var result = _listConverter.GetItem<CustomerResponse>(dataTable.Rows[0]);
                response = result.customerCNIC;
            }
            return response;
        }

        public async Task<string> AddCustomer(CustomerRequest request)
        {
            string response ="";

            string spName = @"SP_AddCustomer";

            Hashtable Param = new Hashtable
                {
                    { "@customerFirstName", request.customerFirstName },
                    { "@customerLastName", request.customerLastName },
                    { "@customerFatherName", request.customerFatherName },
                    { "@customerCNIC", request.customerCNIC },
                    { "@customerPassportNumber", request.customerPassportNumber },
                    { "@customerMobileNumber", request.customerMobileNumber },
                    { "@customerWhatsAppNumber", request.customerWhatsAppNumber },
                    { "@customerAddress", request.customerAddress },
                    { "@customerImagePath", request.customerImagePath },
                    { "@gender", request.gender },
                    { "@modifiedBy", request.modifiedBy },
                };

           string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response =dataTable;
            }

            return response;
        }

        public async Task<string> UpdateCustomer(CustomerRequest request)
        {
            string response = "";

            string spName = @"SP_UpdateCustomer";

            Hashtable Param = new Hashtable
                {
                    { "@customerFirstName", request.customerFirstName },
                    { "@customerLastName", request.customerLastName },
                    { "@customerFatherName", request.customerFatherName },
                    { "@customerCNIC", request.customerCNIC },
                    { "@customerPassportNumber", request.customerPassportNumber },
                    { "@customerMobileNumber", request.customerMobileNumber },
                    { "@customerWhatsAppNumber", request.customerWhatsAppNumber },
                    { "@customerAddress", request.customerAddress },
                    { "@customerImagePath", request.customerImagePath },
                    { "@gender", request.gender },
                    { "@modifiedBy", request.modifiedBy },
                };

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }
    }
}
