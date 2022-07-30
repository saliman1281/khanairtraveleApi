using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DealerModel
{
    public class DealerInfo
    {
        public class DealerInfoRequest
        {
            public int dealerId { get; set; }
            public string dealerCNIC { get; set; }
            public string dealerName { get; set; }
            public string dealerMobile { get; set; }
            public string dealerAddress { get; set; }
            public string? modifiedBy { get; set; }
        }
        public class DealerInfoResponse
        {
            public int dealerId { get; set; }
            public string dealerCNIC { get; set; }
            public string dealerName { get; set; }
            public string dealerMobile { get; set; }
            public string dealerAddress { get; set; }
        }
    }
}
