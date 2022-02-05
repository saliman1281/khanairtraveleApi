using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Customer
    {
        public class CustomerRequest
        {

            public string customerFirstName { get; set; }
            public string customerLastName { get; set; }
            public string customerFatherName { get; set; }
            public string customerCNIC { get; set; }
            public string customerPassportNumber { get; set; }
            public string customerMobileNumber { get; set; }
            public string customerWhatsAppNumber { get; set; }
            public string customerAddress { get; set; }
            public string customerImagePath { get; set; }
            public string gender { get; set; }
            public string modifiedBy { get; set; }

        }

        public class CustomerResponse
        {
            public int customerId { get; set; }
            public string customerFirstName { get; set; }
            public string customerLastName { get; set; }
            public string customerFatherName { get; set; }
            public string customerCNIC { get; set; }
            public string customerPassportNumber { get; set; }
            public string customerMobileNumber { get; set; }
            public string customerWhatsAppNumber { get; set; }
            public string customerAddress { get; set; }
            public string customerImagePath { get; set; }
            public string gender { get; set; }
            public string modifiedBy { get; set; }

        }
    }
}
